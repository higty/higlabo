using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    /// <summary>
    /// 
    /// </summary>
    public static class ListExtensions
    {
        public static void Sort<T, TKey>(this List<T> list, params Func<T, TKey>[] keySelectors)
        {
            List<Comparison<T>> l = new List<Comparison<T>>();

            foreach (var selector in keySelectors)
            {
                l.Add((x, y) => Comparer<TKey>.Default.Compare(selector(x), selector(y)));
            }
            list.Sort<T>(l.ToArray());
        }
        public static void Sort<T>(this List<T> list, params Comparison<T>[] comparisonList)
        {
            Comparison<T> md = (x, y) =>
            {
                foreach (Comparison<T> t in comparisonList)
                {
                    int z = t(x, y);
                    if (z == 0)
                    { continue; }
                    return z;
                }
                return 0;
            };
            list.Sort(md);
        }
        public static void Sort<T, TValue>(this List<T> records, Func<T, TValue, Boolean> func, params TValue[] valueList)
        {
            var l = new List<T>();
            foreach (var name in valueList)
            {
                var rr = records.FindAll(el => func(el, name));
                foreach (var r in rr)
                {
                    records.Remove(r);
                    l.Add(r);
                }
            }
            foreach (var item in records)
            {
                l.Add(item);
            }
            records.Clear();
            records.AddRange(l);
        }

        public static void AddIfNotExist<T>(this List<T> list, T item)
        {
            AddIfNotExist(list, item, (x, y) => Object.Equals(x, y));
        }
        public static void AddIfNotExist<T, TProperty>(this List<T> list, T item, Func<T, TProperty> selectorFunc)
        {
            if (list.Exists(el => Object.Equals(selectorFunc(item), selectorFunc(el))) == false)
            {
                list.Add(item);
            }
        }
        public static void AddIfNotExist<T>(this List<T> list, T item, Func<T, T, Boolean> equalityFunc)
        {
            if (list.Exists(el => equalityFunc(item, el)) == false)
            {
                list.Add(item);
            }
        }

        public static void MoveTo<T>(this List<T> list, Func<T, Boolean> selector, Int32 index)
        {
            var r = list.FirstOrDefault(selector);
            if (r != null)
            {
                list.Remove(r);
                list.Insert(index, r);
            }
        }

        public static T Pop<T>(this List<T> source, Int32 index)
        {
            var o = source[index];
            source.RemoveAt(index);
            return o;
        }
        public static List<T> Pop<T>(this List<T> source, Func<T, Boolean> selector)
        {
            var l = source.Where(selector).ToList();
            for (int i = 0; i < l.Count; i++)
            {
                source.Remove(l[i]);
            }
            return l;
        }
    }
}
