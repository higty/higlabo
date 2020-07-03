using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Internal
{
    internal static class ListExtensions
    {
        public static void AddIfNotExist<T>(this List<T> list, T item, Func<T, T, Boolean> equalityFunc)
        {
            if (list.Exists(el => equalityFunc(item, el)) == false)
            {
                list.Add(item);
            }
        }
    }
}
