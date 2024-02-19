using CatenarySupport.Database;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class DistrictViewProvider : IProviderView<DistrictView>
    {
        private readonly IDatabase database;
        public DistrictViewProvider(IDatabase db)
        {
            database = db;
        }

        public void Insert(DistrictView model)
        {
            database.Insert(model);
        }

        public void Delete(DistrictView model)
        {
            database.Delete(model);
        }
        public void Delete(Expression<Func<DistrictView, bool>> predicate)
        {
            database.Delete(predicate);
        }

        public IEnumerable<DistrictView> Select()
        {
            
            return database.Select<DistrictView>();
        }

        public IEnumerable<DistrictView> Select(Expression<Func<DistrictView, bool>> predicate)
        {
            return database.Select(predicate);
        }

        public void Update(DistrictView model)
        {
            database.Update(model);
        }


    }
}
