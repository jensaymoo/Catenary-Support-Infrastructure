using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CatenarySupport.Database
{
    internal interface IDatabase
    {
        IEnumerable<T> Select<T>() where T : class,  new();
        IEnumerable<T> Select<T>(Expression<Func<T, bool>> expression) where T : class, new();

        void Delete<T>(T obj) where T : class, new();
        void Delete<T>(Expression<Func<T, bool>> expression) where T : class, new();

        void Insert<T>(T obj) where T : class, new();
        void Update<T>(T obj) where T : class, new();

        bool TestConnection();
    }
}
