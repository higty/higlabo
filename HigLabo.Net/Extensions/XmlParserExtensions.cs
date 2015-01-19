using System;
using System.Xml.Linq;

namespace HigLabo.Net.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlParserExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static String CastElementToString(this XElement element, String key)
        {
            if (element.Element(key) == null) { return ""; }
            return element.Element(key).Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean? CastElementToBoolean(this XElement element, String key)
        {
            Boolean x = false;
            if (element.Element(key) == null) { return null; }
            if (Boolean.TryParse(element.Element(key).Value, out x) == true)
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
        /// <returns></returns>
        public static Int32? CastElementToInt32(this XElement element, String key)
        {
            Int32 x = 0;
            if (element.Element(key) == null) { return null; }
            if (Int32.TryParse(element.Element(key).Value, out x) == true)
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
        /// <returns></returns>
        public static Int64? CastElementToInt64(this XElement element, String key)
        {
            Int64 x = 0;
            if (element.Element(key) == null) { return null; }
            if (Int64.TryParse(element.Element(key).Value, out x) == true)
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
        /// <returns></returns>
        public static String CastAttributeToString(this XElement element, String key)
        {
            if (element.Attribute(key) == null) { return ""; }
            return element.Attribute(key).Value;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        public static Boolean? CastAttributeToBoolean(this XElement element, String key)
        {
            Boolean x = false;
            if (element.Attribute(key) == null) { return null; }
            if (Boolean.TryParse(element.Attribute(key).Value, out x) == true)
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
        /// <returns></returns>
        public static Int32? CastAttributeToInt32(this XElement element, String key)
        {
            Int32 x = 0;
            if (element.Attribute(key) == null) { return null; }
            if (Int32.TryParse(element.Attribute(key).Value, out x) == true)
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
        /// <returns></returns>
        public static Int64? CastAttributeToInt64(this XElement element, String key)
        {
            Int64 x = 0;
            if (element.Attribute(key) == null) { return null; }
            if (Int64.TryParse(element.Attribute(key).Value, out x) == true)
            {
                return x;
            }
            return null;
        }
    }
}
