using System;
using System.Collections.Generic;
using System.Xml.Linq;

namespace HigLabo.Core
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
        /// <param name="name"></param>
        /// <returns></returns>
        public static XElement ElementByNamespace(this XElement element, string name)
        {
            return element.ElementByNamespace(null, name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XElement ElementByNamespace(this XElement element, string nameSpace, string name)
        {
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            return element.Element(ns + name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ElementsByNamespace(this XElement element, string name)
        {
            return element.ElementsByNamespace(null, name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static IEnumerable<XElement> ElementsByNamespace(this XElement element, string nameSpace, string name)
        {
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            return element.Elements(ns + name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XAttribute AttributeByNamespace(this XElement element, string name)
        {
            return element.AttributeByNamespace(null, name);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XAttribute AttributeByNamespace(this XElement element, string nameSpace, string name)
        {
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            if (ns == null) { return element.Attribute(name); }
            return element.Attribute(ns + name) ?? element.Attribute(name);
        }
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
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CastElementToString(this XElement element, string nameSpace, string name)
        {
            var e = element.ElementByNamespace(nameSpace, name);
            return e == null ? null : e.Value;
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
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CastAttributeToString(this XElement element, string nameSpace, string name)
        {
            var a = element.AttributeByNamespace(nameSpace, name);
            return a == null ? null : a.Value;
        }
    }
}
