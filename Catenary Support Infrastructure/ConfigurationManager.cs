using FluentValidation;
using Newtonsoft.Json;
using System.Diagnostics;

namespace CatenarySupport
{
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
                .NotEmpty();

            RuleFor(opt => opt.ConnectionString)
                .NotNull()
                .NotEmpty();
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
                var config_path = Path.Combine(Directory.GetCurrentDirectory(), "config.json");
                var config_string = File.ReadAllText(config_path);

                lock (sync)
                {
                    if (instance == null)
                    {
                        instance = JsonConvert.DeserializeObject<Configuration>(config_string)!;

                        var validator = new ConfigurationValidator();
                        validator.ValidateAndThrow(instance);
                    }
                }

            }
            return instance;
        }
    }
}
