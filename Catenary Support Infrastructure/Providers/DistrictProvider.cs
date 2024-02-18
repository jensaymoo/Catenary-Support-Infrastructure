using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using LinqToDB;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class DistrictProvider : IProvider<DistrictObject>
    {
        private readonly IDatabase database;
        public DistrictProvider(IDatabase db)
        {
            database = db;
            //database.CreateTable<DistrictData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Insert(DistrictObject model)
        {
            database.Insert(model);
        }

        public void Delete(DistrictObject model)
        {
            database.Delete(model);
        }
        public void Delete(Expression<Func<DistrictObject, bool>> predicate)
        {
            database.Delete(predicate);
        }

        public IEnumerable<DistrictObject> Select()
        {
            
            return database.Select<DistrictObject>();
        }

        public IEnumerable<DistrictObject> Select(Expression<Func<DistrictObject, bool>> predicate)
        {
            return database.Select(predicate);
        }

        public void Update(DistrictObject model)
        {
            database.Update(model);
        }


    }
}
