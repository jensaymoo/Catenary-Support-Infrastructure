using CatenarySupport.Database;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport
{
    internal class ConfigurationValidator : AbstractValidator<Configuration>
    {
        public ConfigurationValidator()
        {
            RuleFor(opt => opt.DatabaseProvider)
                .NotNull()
                .NotEmpty()
                .Custom((config, context) =>
                {
                    try
                    {
                        var providerType = Assembly.GetExecutingAssembly().GetTypes()
                            .Where(t => t.Name == config && t.IsClass && t.GetInterface(nameof(IDatabase)) != null).Single();
                    }
                    catch
                    {
                        context.AddFailure(context.DisplayName, $"Не удалось найти провайдер '{config}' для подключение к базе данных. Проверьте параметр '{context.PropertyPath}'.");
                    }
                });


            RuleFor(opt => opt.ConnectionString)
                .NotNull()
                .NotEmpty();

            //RuleFor(opt => opt)
            //    .Custom((config, context) =>
            //    {
            //        try
            //        {
            //            using (var db = new DataContext(config.DatabaseProvider!, config.ConnectionString!))
            //            {
            //                db.RunInTransaction(() =>
            //                {
            //                    var temp_uuid = Guid.NewGuid().ToString("N");

            //                    db.CreateTable<MastData>(temp_uuid);
            //                    db.DropTable<MastData>(temp_uuid);
            //                });

            //            }
            //        }
            //        catch
            //        {
            //            context.AddFailure("DatabaseProvider, ConnectionString", "Не удалось проверить подключение к базе данных. Проверьте параметры 'DatabaseProvider' и 'ConnectionString'.");
            //        }
            //    });
        }
    }
}
