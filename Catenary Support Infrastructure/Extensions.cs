using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CatenarySupport
{
    internal static class Extensions
    {
        public static void RunInTransaction(this DataContext context, Action action)
        {
            var transaction = context.BeginTransaction();

            action();

            transaction.CommitTransaction();
        }
        public static void ForEach<T>(this IEnumerable<T> @this, Action<T> action)
        {
            foreach (T item in @this)
            {
                action(item);
            }


        }
        public static IEnumerable<V> SelectNotNull<T, V>(this IEnumerable<T> items, Func<T, V> func) where V : class
        {
            foreach (var item in items)
            {
                var value = func(item);
                if (value != null)
                    yield return value;
            }
        }

        public static IEnumerable<V> SelectNotNull<T, V>(this IEnumerable<T> items, Func<T, V?> func) where V : struct
        {
            foreach (var item in items)
            {
                var value = func(item);
                if (value.HasValue)
                    yield return value.Value;
            }
        }
    }
}