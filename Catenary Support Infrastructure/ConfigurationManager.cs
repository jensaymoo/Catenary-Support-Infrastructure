using CatenarySupport.Database.Tables;
using FluentValidation;
using LinqToDB;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CatenarySupport
{
    internal enum SupportedDatabaseProviders
    { SQLite }

    internal class Configuration
    {
        public string? DatabaseProvider { get; set; }
        public string? ConnectionString { get; set; }

    }
    internal class ConfigurationValidator : AbstractValidator<Configuration>
    {
        public ConfigurationValidator()
        {
            RuleFor(opt => opt.DatabaseProvider)
                .NotNull()
                .NotEmpty()
                .IsEnumName(typeof(SupportedDatabaseProviders));

            RuleFor(opt => opt.ConnectionString)
                .NotNull()
                .NotEmpty();

            RuleFor(opt => opt)
                .Custom((config, context) =>
                {
                    try
                    {
                        using (var db = new DataContext(config.DatabaseProvider!, config.ConnectionString!))
                        {
                            db.RunInTransaction(() =>
                            {
                                var temp_uuid = Guid.NewGuid().ToString("N");

                                db.CreateTable<PillarData>(temp_uuid);
                                db.DropTable<PillarData>(temp_uuid);
                            });

                        }
                    }
                    catch 
                    {
                        context.AddFailure("DatabaseProvider, ConnectionString", "Не удалось проверить подключение к базе данных. Проверьте параметры 'DatabaseProvider' и 'ConnectionString'.");
                    }
                });
        }
    }
    internal class ConfigurationManager
    {
        private static Configuration instance;
        private static object sync = new();

        private ConfigurationManager() { }

        public static Configuration GetConfiguration()
        {
            if (instance == null)
            {
                lock (sync)
                {
                    if (instance == null)
                    {
                        try
                        {
                            var config_path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
                            var config_string = File.ReadAllText(config_path);

                            instance = JsonConvert.DeserializeObject<Configuration>(config_string)!;

                            try
                            {
                                var validator = new ConfigurationValidator();
                                validator.ValidateAndThrow(instance);
                            } 
                            catch (ValidationException ex)
                            {

                                var errors = ex.Errors.Select((t) => "-- " + t.ErrorMessage)
                                    .Aggregate((prev, current) => prev + "\n\n" + current);

                                throw new Exception(errors);
                            }

                        }
                        catch (Exception ex)
                        {
                            throw new Exception($"Неудалось выполнить загрузку параметров из файла 'config.json':\n\n{ex.Message}");
                        }


                    }
                }

            }
            return instance;
        }
    }
}
