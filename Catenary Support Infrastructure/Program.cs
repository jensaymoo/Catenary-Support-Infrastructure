using Autofac;
using AutoMapper;
using AutoMapper.Extensions.ExpressionMapping;
using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using CatenarySupport.Providers;
using DevExpress.XtraPrinting.BarCode;
using LinqToDB;
using System.Reflection;

namespace CatenarySupport
{
    internal static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();

            var builder = new ContainerBuilder();
            ILifetimeScope scope;

            try
            {
                builder.RegisterType<ConfigurationProviderJson>()
                    .As<IConfigurationProvider>()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .Where(t => t.Name == new ConfigurationProviderJson().Configuration.DatabaseProvider!)
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                    .Where(t => t.Name.EndsWith("ViewProvider"))
                    .AsImplementedInterfaces()
                    .InstancePerLifetimeScope();

                builder.RegisterType<Main>();
                scope = builder.Build().BeginLifetimeScope();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            Application.Run(scope.Resolve<Main>());
        }
    }
}