using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport.Providers
{
    public interface IProvider<T> where T : class
    {
        public void Add(T model);
        public void Update(T model);
        public void Delete(T model);

        public IEnumerable<T> Get();
        public IEnumerable<T> Get(Func<T, bool> predicate);

    }
}
