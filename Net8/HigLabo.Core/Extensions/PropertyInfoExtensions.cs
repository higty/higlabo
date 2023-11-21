using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;

namespace HigLabo.Core
{
    public static class PropertyInfoExtensions
    {
        public static Delegate GetValueGetter(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.DeclaringType == null) { throw new ArgumentException("propertyInfo.DeclaringType must not be null."); }

            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var property = Expression.Property(instance, propertyInfo);
            var convert = Expression.TypeAs(property, typeof(object));

            return Expression.Lambda(convert, instance).Compile();
        }
        public static Delegate GetValueSetter(this PropertyInfo propertyInfo)
        {
            if (propertyInfo.DeclaringType == null) { throw new ArgumentException("propertyInfo.DeclaringType must not be null."); }
            var setMethod = propertyInfo.GetSetMethod();
            if (setMethod == null) { throw new ArgumentException("This propertyInfo does not have setter property."); }

            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var argument = Expression.Parameter(typeof(object), "a");
            var setterCall = Expression.Call(instance, setMethod, Expression.Convert(argument, propertyInfo.PropertyType));

            return Expression.Lambda(setterCall, instance, argument).Compile();
        }
        public static Func<T, Object> GetValueGetter<T>(this PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }
            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var property = Expression.Property(instance, propertyInfo);
            var convert = Expression.TypeAs(property, typeof(object));

            return (Func<T, object>)Expression.Lambda(convert, instance).Compile();

        }
        public static Action<T, Object> GetValueSetter<T>(this PropertyInfo propertyInfo)
        {
            if (typeof(T) != propertyInfo.DeclaringType)
            {
                throw new ArgumentException();
            }
            var setMethod = propertyInfo.GetSetMethod();
            if (setMethod == null) { throw new ArgumentException("This propertyInfo does not have setter property."); }

            var instance = Expression.Parameter(propertyInfo.DeclaringType, "i");
            var argument = Expression.Parameter(typeof(object), "a");
            var setterCall = Expression.Call(instance, setMethod, Expression.Convert(argument, propertyInfo.PropertyType));

            return (Action<T, object>)Expression.Lambda(setterCall, instance, argument).Compile();
        }
    }
}
