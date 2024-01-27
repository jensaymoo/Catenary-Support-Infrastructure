using Autofac;
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

            Configuration config = null;
            try
            {
                config = ConfigurationManager.GetConfiguration();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Îøèáêà", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var builder = new ContainerBuilder();
            
            builder.Register(x => new DataContext(config.DatabaseProvider!, config.ConnectionString!))
                .As<IDataContext>()
                .InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(Assembly.GetExecutingAssembly())
                .Where(t => t.Name.EndsWith("Provider"))
                .AsImplementedInterfaces()
                .InstancePerLifetimeScope();

            builder.RegisterType<MainForm>();

            var scope = builder.Build().BeginLifetimeScope();
            

            Application.Run(scope.Resolve<MainForm>());
        }
    }
}