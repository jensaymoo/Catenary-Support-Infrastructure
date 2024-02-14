using CatenarySupport.Database;
using CatenarySupport.Database.Tables;
using LinqToDB;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class PlantProvider : IProvider<PlantData>
    {
        private readonly IDatabase datacontext;
        public PlantProvider(IDatabase db)
        {
            datacontext = db;
            //datacontext.CreateTable<PlantData>(tableOptions: TableOptions.CreateIfNotExists);
        }

        public void Insert(PlantData model)
        {
            datacontext.Insert(model);
        }

        public void Delete(PlantData model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<PlantData, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<PlantData> Select()
        {
            return datacontext.Select<PlantData>();
        }

        public IEnumerable<PlantData> Get(Expression<Func<PlantData, bool>> predicate)
        {
            return datacontext.Select<PlantData>(predicate);
        }

        public void Update(PlantData model)
        {
            datacontext.Update(model);
        }
    }
}
