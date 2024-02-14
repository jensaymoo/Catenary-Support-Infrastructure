using System.Collections.Concurrent;
using System.Linq.Expressions;
using System.Reflection;

namespace CatenarySupport
{
    internal class MemberAcessor<T>
    {
        private readonly ConcurrentDictionary<string, Func<T, object>?> cache_fields = new();
        public bool TryCallMethodWithoutParams(T instance, string methodName, out object? value)
        {
            var func = cache_fields.GetOrAdd(methodName,
                static (methodName, instance) =>
                {
                    const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;
                    var objParameterExpr = Expression.Parameter(typeof(T));
                    ParameterExpression param = Expression.Parameter(typeof(int));

                    var type = instance!.GetType();
                    Expression? methtodExpression = null;

                    var instanceExpr = Expression.TypeAs(objParameterExpr, instance.GetType());
                    MethodInfo methodInfo = type.GetMethod(methodName, flags, Array.Empty<Type>())!;

                    if (methodInfo != null)
                    {
                        methtodExpression = Expression.Call(instanceExpr, methodInfo);
                    }

                    if (methtodExpression == null)
                    {
                        return null;
                    }

                    return Expression.Lambda<Func<T, object>>(methtodExpression, objParameterExpr).Compile();
                }, instance);

            if (func == null)
            {
                value = null;
                return false;
            }

            value = func(instance);
            return true;
        }

        public bool TryGetFieldOrProperty(T instance, string fieldOrPropertyName, out object? value)
        {
            var func = cache_fields.GetOrAdd(fieldOrPropertyName,
                static (fieldOrPropertyName, instance) =>
                {
                    const BindingFlags flags = BindingFlags.Instance | BindingFlags.Public | BindingFlags.IgnoreCase;
                    var objParameterExpr = Expression.Parameter(typeof(T));
                    var type = instance!.GetType();
                    Expression? memberExpression = null;

                    var instanceExpr = Expression.TypeAs(objParameterExpr, instance.GetType());
                    PropertyInfo propertyInfo = type.GetProperty(fieldOrPropertyName, flags)!;
                    if (propertyInfo != null)
                    {
                        memberExpression = Expression.Property(instanceExpr, propertyInfo);
                    }
                    else
                    {
                        FieldInfo fieldInfo = type.GetField(fieldOrPropertyName, flags)!;
                        if (fieldInfo != null)
                        {
                            memberExpression = Expression.Field(instanceExpr, fieldInfo);
                        }
                    }

                    if (memberExpression == null)
                    {
                        return null;
                    }

                    return Expression.Lambda<Func<T, object>>(memberExpression, objParameterExpr).Compile();
                }, instance);

            if (func == null)
            {
                value = null;
                return false;
            }

            value = func(instance);
            return true;
        }
    }

}
