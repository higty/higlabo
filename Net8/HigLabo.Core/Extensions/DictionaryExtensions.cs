using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Core
{
    public static class DictionaryExtensions
    {
        public static string GetValueOrDefault(this Dictionary<string, string> dictionary, string key)
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            return "";
        }
        public static TValue? GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue?> dictionary, TKey key)
            where TKey : notnull
        {
            return GetValueOrDefault(dictionary, key, default(TValue?));
        }
        public static TValue? GetValueOrDefault<TKey, TValue>(this Dictionary<TKey, TValue?> dictionary, TKey key, TValue defaultValue)
            where TKey : notnull
        {
            if (dictionary.TryGetValue(key, out var value))
            {
                return value;
            }
            return defaultValue;
        }
    }
}
