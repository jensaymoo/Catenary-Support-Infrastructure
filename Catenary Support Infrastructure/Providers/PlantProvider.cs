using CatenarySupport.Database;
using CatenarySupport.Providers.Objects;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class PlantProvider : IProvider<PlantObject>
    {
        private readonly IDatabase datacontext;
        public PlantProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(PlantObject model)
        {
            datacontext.Insert(model);
        }

        public void Delete(PlantObject model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<PlantObject, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<PlantObject> Select()
        {
            return datacontext.Select<PlantObject>();
        }

        public IEnumerable<PlantObject> Select(Expression<Func<PlantObject, bool>> predicate)
        {
            return datacontext.Select<PlantObject>(predicate);
        }

        public void Update(PlantObject model)
        {
            datacontext.Update(model);
        }
    }
}
