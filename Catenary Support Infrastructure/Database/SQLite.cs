using LinqToDB;
using System.Linq.Expressions;

namespace CatenarySupport.Database
{
    internal class SQLite : IDatabase
    {
        DataContext context;
        public SQLite(IConfigurationProvider сonfigurationProvider)
        {
            context = new DataContext("SQLite", сonfigurationProvider.Configuration.ConnectionString!);
        }

        public void Delete<T>(T obj) where T : class, new()
        {
            context.Delete(obj);
        }

        public void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            context.GetTable<T>().Delete(expression);
        }

        public void Insert<T>(T obj) where T : class, new()
        {
            context.CreateTable<T>(tableOptions: TableOptions.CreateIfNotExists);
            context.Insert(obj);
        }

        public IEnumerable<T> Select<T>() where T : class, new()
        {
            return context.GetTable<T>();
        }

        public IEnumerable<T> Select<T>(Expression<Func<T, bool>> expression) where T : class, new()
        {
            return context.GetTable<T>().Where(expression);
        }

        public void Update<T>(T obj) where T : class, new()
        {
            context.Update(obj);
        }

        public bool TestConnection()
        {
            throw new NotImplementedException();
        }
    }
}
