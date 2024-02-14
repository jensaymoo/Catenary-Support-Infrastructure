using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Providers
{
    public interface IProvider<T> where T : class
    {
        public void Insert(T model);
        public void Update(T model);
        public void Delete(T model);
        public void Delete(Expression<Func<T, bool>> predicate);

        public IEnumerable<T> Select();
        public IEnumerable<T> Get(Expression<Func<T, bool>> predicate);

    }
}
