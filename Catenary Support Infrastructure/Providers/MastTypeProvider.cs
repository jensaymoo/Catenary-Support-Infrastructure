using CatenarySupport.Database;
using CatenarySupport.Providers.Views;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    internal class MastTypeProvider : IProviderView<MastTypeView>
    {
        private readonly IDatabase datacontext;
        public MastTypeProvider(IDatabase db)
        {
            datacontext = db;
        }

        public void Insert(MastTypeView model)
        {
            datacontext.Insert(model);
        }

        public void Delete(MastTypeView model)
        {
            datacontext.Delete(model);
        }
        public void Delete(Expression<Func<MastTypeView, bool>> predicate)
        {
            datacontext.Delete(predicate);
        }

        public IEnumerable<MastTypeView> Select()
        {
            return datacontext.Select<MastTypeView>();
        }

        public IEnumerable<MastTypeView> Select(Expression<Func<MastTypeView, bool>> predicate)
        {
            return datacontext.Select<MastTypeView>(predicate);
        }

        public void Update(MastTypeView model)
        {
            datacontext.Update(model);
        }
    }
}
