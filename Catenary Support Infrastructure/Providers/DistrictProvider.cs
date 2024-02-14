using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using LinqToDB;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class DistrictProvider : IProvider<DistrictData>
    {
        private readonly IDatabase database;
        public DistrictProvider(IDatabase db)
        {
            database = db;
            //database.CreateTable<DistrictData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Insert(DistrictData model)
        {
            database.Insert(model);
        }

        public void Delete(DistrictData model)
        {
            database.Delete(model);
        }
        public void Delete(Expression<Func<DistrictData, bool>> predicate)
        {
            database.Delete(predicate);
        }

        public IEnumerable<DistrictData> Select()
        {
            
            return database.Select<DistrictData>();
        }

        public IEnumerable<DistrictData> Get(Expression<Func<DistrictData, bool>> predicate)
        {
            return database.Select(predicate);
        }

        public void Update(DistrictData model)
        {
            database.Update(model);
        }


    }
}
