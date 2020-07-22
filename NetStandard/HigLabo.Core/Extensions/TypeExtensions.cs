using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class TypeExtensions
    {
        public static Boolean IsImplementInterface(this Type type, Type interfaceType)
        {
            return type.GetInterfaces().Any(x => x == interfaceType);
        }
        public static Boolean IsInheritanceFrom(this Type type, Type parentType)
        {
            if (parentType.IsGenericTypeDefinition == false)
            {
                //代入可能→継承している
                return parentType.IsAssignableFrom(type);
            }
            //親クラスの一覧を保持する変数
            var parentTypes = new List<Type> { type };
            //親クラスがインターフェースの場合、実装するインターフェースを全てリストに追加
            if (parentType.IsInterface == true)
            {
                parentTypes.AddRange(type.GetInterfaces());
            }
            var basedOn = type;
            //対象オブジェクトの親クラスを全てリストに追加
            while (basedOn.BaseType != null)
            {
                parentTypes.Add(basedOn.BaseType);
                basedOn = basedOn.BaseType;
            }
            //リストに含まれているかどうかチェック
            return parentTypes.Any(x => x.IsGenericType && x.GetGenericTypeDefinition() == parentType);
        }
        public static Boolean IsNumber(this Type type)
        {
            if (type == typeof(SByte)) { return true; }
            if (type == typeof(Int16)) { return true; }
            if (type == typeof(Int32)) { return true; }
            if (type == typeof(Int64)) { return true; }
            if (type == typeof(Byte)) { return true; }
            if (type == typeof(UInt16)) { return true; }
            if (type == typeof(UInt32)) { return true; }
            if (type == typeof(UInt64)) { return true; }
            if (type == typeof(Single)) { return true; }
            if (type == typeof(Double)) { return true; }
            if (type == typeof(Decimal)) { return true; }

            return false;
        }
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
        public static String GetTypeName(this Type type)
        {
            var l = type.GetGenericArguments();
            if (l.Length == 0)
            {
                return type.Name;
            }
            else
            {
                var sb = new StringBuilder();
                sb.Append(type.Name.ExtractString(null, '`'));
                sb.Append("<");
                for (int i = 0; i < l.Length; i++)
                {
                    sb.Append(l[i].GetTypeName());
                    if (i < l.Length - 1)
                    {
                        sb.Append(", ");
                    }
                }
                sb.Append(">");
                return sb.ToString();
            }
        }
    }
}
