using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class TypeExtensions
    {
        public static bool IsInheritanceFrom(this Type type, Type parentType)
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
    }
}
