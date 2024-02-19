using CatenarySupport.Database;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class PlantViewProvider : IProvider<PlantView>
    {
        private readonly IDatabase datacontext;
        public PlantViewProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(PlantView model)
        {
            datacontext.Insert(model);
        }

        public void Delete(PlantView model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<PlantView, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<PlantView> Select()
        {
            return datacontext.Select<PlantView>();
        }

        public IEnumerable<PlantView> Select(Expression<Func<PlantView, bool>> predicate)
        {
            return datacontext.Select<PlantView>(predicate);
        }

        public void Update(PlantView model)
        {
            datacontext.Update(model);
        }
    }
}
