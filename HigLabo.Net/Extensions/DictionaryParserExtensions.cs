using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace HigLabo.Net.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class DictionaryParserExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String ToString(this Dictionary<String, Object> element, String key)
        {
            if (element.ContainsKey(key) == false || element[key] == null) { return ""; }
            return element[key].ToString();
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean? ToBoolean(this Dictionary<String, Object> element, String key)
        {
            Boolean x = false;
            if (element.ContainsKey(key) == false || element[key] == null) { return null; }
            var o = element[key];
            if (o is Boolean) { return (Boolean)o; }
            if (o.ToString() == "0") { return false; }
            if (o.ToString() == "1") { return true; }
            if (Boolean.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Boolean ToBoolean(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToBoolean(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Int32? ToInt32(this Dictionary<String, Object> element, String key)
        {
            Int32 x = 0;
            if (element.ContainsKey(key) == false || element[key] == null) { return null; }
            var o = element[key];
            if (o is Int32) { return (Int32)o; }
            if (Int32.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Int32 ToInt32(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToInt32(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Int64? ToInt64(this Dictionary<String, Object> element, String key)
        {
            Int64 x = 0;
            if (element.ContainsKey(key) == false || element[key] == null) { return null; }
            var o = element[key];
            if (o is Int64) { return (Int64)o; }
            if (Int64.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Int64 ToInt64(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToInt64(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Double? ToDouble(this Dictionary<String, Object> element, String key)
        {
            Double x = 0;
            if (element.ContainsKey(key) == false || element[key] == null) { return null; }
            var o = element[key];
            if (o is Double) { return (Double)o; }
            if (Double.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static Double ToDouble(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToDouble(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DateTime? ToDateTime(this Dictionary<String, Object> element, String key)
        {
            DateTime x = DateTime.MinValue;
            if (element.ContainsKey(key) == false || element[key] == null) { return null; }
            var o = element[key];
            if (o is DateTime) { return (DateTime)o; }
            if (DateTime.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static DateTime ToDateTime(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToDateTime(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static DateTimeOffset? ToDateTimeOffset(this Dictionary<String, Object> element, String key)
        {
            DateTimeOffset x = DateTimeOffset.MinValue;
            if (element.ContainsKey(key) == false || element[key] == null) 
            { return null; }
            var o = element[key];
            if (o is DateTimeOffset) { return (DateTimeOffset)o; }
            if (DateTimeOffset.TryParse(o.ToString(), out x) == true)
            {
                return x;
            }
            return null;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <param name="exception"></param>
        /// <returns></returns>
        public static DateTimeOffset ToDateTimeOffset(this Dictionary<String, Object> element, String key, Exception exception)
        {
            var rs = ToDateTimeOffset(element, key);
            if (rs.HasValue == false) { throw exception; }
            return rs.Value;
        }
    }
}
