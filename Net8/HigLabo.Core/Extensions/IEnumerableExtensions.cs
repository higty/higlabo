using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core;

public static class IEnumerableExtensions
{
    public static IEnumerable<T> OrderBy<T>(this IEnumerable<T> source)
    {
        return source.OrderBy(el => el);
    }
    public static IEnumerable<T> OrderByDescending<T>(this IEnumerable<T> source)
    {
        return source.OrderByDescending(el => el);
    }
    public static IEnumerable<T> OrderBy<T, TKey>(this IEnumerable<T> source, params Func<T, TKey>[] keySelectors)
    {
        var list = System.Linq.Enumerable.OrderBy(source, keySelectors[0]);
        for (int i = 1; i < keySelectors.Length; i++)
        {
            list = list.ThenBy(keySelectors[i]);
        }
        return list;
    }
    public static IEnumerable<T> OrderByDescending<T, TKey>(this IEnumerable<T> source, params Func<T, TKey>[] keySelectors)
    {
        var list = System.Linq.Enumerable.OrderByDescending(source, keySelectors[0]);
        for (int i = 1; i < keySelectors.Length; i++)
        {
            list = list.ThenByDescending(keySelectors[i]);
        }
        return list;
    }

    public static Boolean Contains<T>(this IEnumerable<T> source, T value, Func<T, T, Boolean> equalityFunc)
    {
        return source.Contains(value, new EqualityFunc<T>(equalityFunc));
    }
    public static Boolean Exists<T>(this IEnumerable<T> source, Func<T, Boolean> predicate)
    {
        return source.FirstOrDefault(predicate) != null;
    }

    public static IEnumerable<T> Distinct<T>(this IEnumerable<T> source, Func<T, T, Boolean> equalityFunc)
    {
        return source.Distinct(new EqualityFunc<T>(equalityFunc));
    }
    public static IEnumerable<T> Except<T>(this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, Boolean> equalityFunc)
    {
        return source.Except(second, new EqualityFunc<T>(equalityFunc));
    }
    public static IEnumerable<T> Intersect<T>(this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, Boolean> equalityFunc)
    {
        return source.Intersect(second, new EqualityFunc<T>(equalityFunc));
    }
    public static IEnumerable<T> Union<T>(this IEnumerable<T> source, IEnumerable<T> second, Func<T, T, Boolean> equalityFunc)
    {
        return source.Union(second, new EqualityFunc<T>(equalityFunc));
    }

    public static IEnumerable<T> SelectMany<T>(this IEnumerable<IEnumerable<T>> source)
    {
        return System.Linq.Enumerable.SelectMany(source, el => el);
    }
}
