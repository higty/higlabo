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
        public static XElement? ElementByNamespace(this XElement? element, string name)
        {
            return element.ElementByNamespace(null, name);
        }
        public static XElement? ElementByNamespace(this XElement? element, string? nameSpace, string name)
        {
            if (element == null) { return null; }
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            if (ns == null)
            {
                ns = element.GetDefaultNamespace();
            }
            return element.Element(ns + name);
        }
        public static IEnumerable<XElement> ElementsByNamespace(this XElement? element, string name)
        {
            return element.ElementsByNamespace(null, name);
        }
        public static IEnumerable<XElement> ElementsByNamespace(this XElement? element, string? nameSpace, string name)
        {
            if (element == null) { yield break; }
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            if (ns == null) { yield break; }
            foreach (var item in element.Elements(ns + name))
            {
                yield return item;
            }
        }
        public static XAttribute? AttributeByNamespace(this XElement? element, string name)
        {
            return element.AttributeByNamespace(null, name);
        }
        public static XAttribute? AttributeByNamespace(this XElement? element, string? nameSpace, string name)
        {
            if (element == null) { return null; }
            var ns = String.IsNullOrEmpty(nameSpace) ? element.GetDefaultNamespace() : element.GetNamespaceOfPrefix(nameSpace);
            if (ns == null) { return element.Attribute(name); }
            return element.Attribute(ns + name) ?? element.Attribute(name);
        }
        public static string? CastElementToString(this XElement? element, String name)
        {
            return element.CastElementToString("", name);
        }
        public static string? CastElementToString(this XElement? element, string nameSpace, string name)
        {
            var e = element.ElementByNamespace(nameSpace, name);
            return e == null ? null : e.Value;
        }
        public static string? CastAttributeToString(this XElement? element, String name)
        {
            return element.CastAttributeToString("", name);
        }
        public static string? CastAttributeToString(this XElement? element, string nameSpace, string name)
        {
            var a = element.AttributeByNamespace(nameSpace, name);
            return a == null ? null : a.Value;
        }
    }
}
