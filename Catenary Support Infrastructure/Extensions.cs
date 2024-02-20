using LinqToDB;
using System.Collections;
using System.Linq.Expressions;

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

        public static void AddCollection<T>(this BindingSource @this, IEnumerable<T> obj)
        {
            obj.ForEach(a => @this.Add(a));
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
        public static bool IsAssignableToGeneric(
            this Type assignableFrom,
            Type assignableTo)
        {
            bool IsType(Type comparand)
                => assignableTo.IsAssignableFrom(comparand)
                    || (comparand.IsGenericType
                    && comparand.GetGenericTypeDefinition() == assignableTo);

            while (assignableFrom != null)
            {
                if (IsType(assignableFrom)
                    || assignableFrom
                    .GetInterfaces()
                    .Any(IsType))
                {
                    return true;
                }

                assignableFrom = assignableFrom.BaseType!;
            }

            return false;
        }
    }
}