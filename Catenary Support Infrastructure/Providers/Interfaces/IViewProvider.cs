using CatenarySupport.Providers.View;
using System.Linq.Expressions;

namespace CatenarySupport.Providers
{
    public interface IViewProvider<T> where T : class, IViewObject
    {
        public void Insert(T model);
        public void Update(T model);
        public void Delete(T model);
        public void Delete(Expression<Func<T, bool>> predicate);

        public IEnumerable<T> Select();
        public IEnumerable<T> Select(Expression<Func<T, bool>> predicate);

    }
}
