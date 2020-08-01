using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;

namespace HigLabo.Core
{
    internal static class TypeExtensions
    {
        private static readonly String System_Collections_Generic_Dictionary = "System.Collections.Generic.Dictionary";
        private static readonly String System_Collections_Generic_ICollection_1 = "System.Collections.Generic.ICollection`1";
        private static readonly String System_Collections_Generic_IEnumerable_1 = "System.Collections.Generic.IEnumerable`1";

        public static Type[] GetBaseClasses(this Type type)
        {
            List<Type> l = new List<Type>();
            var tp = type;
            while (true)
            {
                tp = tp.BaseType;
                if (tp == null) { break; }
                l.Add(tp);
            }
            return l.ToArray();
        }
        public static PropertyInfo GetIndexerProperty(this Type type)
        {
            var a = type.GetCustomAttributes<DefaultMemberAttribute>().FirstOrDefault();
            if (a is null) { return null; }

            return type.GetProperty(a.MemberName, BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
        }
        public static Boolean IsDictionary(this Type type)
        {
            return type.FullName.StartsWith(System_Collections_Generic_Dictionary) ||
                type.GetInterfaces().Any(tp => tp.FullName.StartsWith(System_Collections_Generic_Dictionary));
        }
        public static Boolean IsIEnumerableT(this Type type)
        {
            return type.FullName.StartsWith(System_Collections_Generic_IEnumerable_1) ||
                type.GetInterfaces().Any(tp => tp.FullName.StartsWith(System_Collections_Generic_IEnumerable_1));
        }
        public static Boolean IsICollectionT(this Type type)
        {
            return type.FullName.StartsWith(System_Collections_Generic_ICollection_1) ||
                type.GetInterfaces().Any(tp => tp.FullName.StartsWith(System_Collections_Generic_ICollection_1));
        }
        public static Boolean IsNullable(this Type type)
        {
            return type.FullName.StartsWith("System.Nullable`1[");
        }
        public static Boolean IsNumber(Type type)
        {
            return type == typeof(SByte) || type == typeof(Int16) || type == typeof(Int32) || type == typeof(Int64) ||
                type == typeof(Byte) || type == typeof(UInt16) || type == typeof(UInt32) || type == typeof(UInt64) ||
                type == typeof(Single) || type == typeof(Double) || type == typeof(Decimal);
        }
        public static Type GetCollectionElementType(this Type type)
        {
            if (type.IsArray) { type.GetElementType(); }
            if (IsGenericEnumerableType(type)) { return type.GetGenericArguments()[0]; }
            var arrayType = Array.Find(type.GetInterfaces(), IsGenericEnumerableType);
            if (arrayType == null) { return typeof(Object); }
            return arrayType.GetGenericArguments()[0];
        }
        private static Boolean IsGenericEnumerableType(this Type type)
        {
            return type.IsGenericType && type.GetGenericTypeDefinition() == typeof(IEnumerable<>);
        }
    }
}
