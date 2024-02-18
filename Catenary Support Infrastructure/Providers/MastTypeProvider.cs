using CatenarySupport.Database;
using CatenarySupport.Providers.Objects;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class MastTypeProvider : IProvider<MastTypeObject>
    {
        private readonly IDatabase datacontext;
        public MastTypeProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastTypeObject model)
        {
            datacontext.Insert(model);
        }

        public void Delete(MastTypeObject model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastTypeObject, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<MastTypeObject> Select()
        {
            return datacontext.Select<MastTypeObject>();
        }

        public IEnumerable<MastTypeObject> Select(Expression<Func<MastTypeObject, bool>> predicate)
        {
            return datacontext.Select<MastTypeObject>(predicate);
        }

        public void Update(MastTypeObject model)
        {
            datacontext.Update(model);
        }
    }
}
