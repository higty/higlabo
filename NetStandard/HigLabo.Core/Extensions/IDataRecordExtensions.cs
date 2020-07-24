using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace HigLabo.Core
{
    public static class IDataRecordExtensions
    {
        public static Dictionary<String, Object> CreateDisctionary(this System.Data.IDataRecord record)
        {
            return record.SetToDisctionary(new Dictionary<String, Object>());
        }
        public static Dictionary<String, Object> CreateDisctionary(this System.Data.IDataRecord record, StringComparer comparer)
        {
            return record.SetToDisctionary(new Dictionary<String, Object>(comparer));
        }
        public static T CreateDisctionary<T>(this System.Data.IDataRecord record)
            where T: IDictionary<String, Object>, new()
        {
            return record.SetToDisctionary(new T());
        }
        public static T SetToDisctionary<T>(this System.Data.IDataRecord record, T dictionary)
            where T: IDictionary<String, Object>, new()
        {
            var fieldCount = record.FieldCount;
            for (int i = 0; i < fieldCount; i++)
            {
                var key = record.GetName(i);
                dictionary[key] = record[key];
            }
            return dictionary;
        }
    }
}
