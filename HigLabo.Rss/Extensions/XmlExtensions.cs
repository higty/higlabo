using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace HigLabo.Rss.Extensions
{
    /// <summary>
    /// 
    /// </summary>
    public static class XmlExtensions
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
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CastElementToString(this XElement element, string name)
        {
            return element.CastElementToString(null, name);
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
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool? CastElementToBoolean(this XElement element, string name)
        {
            return element.CastElementToBoolean(null, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool? CastElementToBoolean(this XElement element, string nameSpace, string name)
        {
            var e = element.ElementByNamespace(nameSpace, name);
            if (e == null)
            {
                return null;
            }

            bool x;
            if (Boolean.TryParse(e.Value, out x))
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int? CastElementToInt32(this XElement element, string name)
        {
            return element.CastElementToInt32(null, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int? CastElementToInt32(this XElement element, string nameSpace, string name)
        {
            var e = element.ElementByNamespace(nameSpace, name);
            if (e == null)
            {
                return null;
            }

            int x;
            if (Int32.TryParse(e.Value, out x))
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static string CastAttributeToString(this XElement element, string name)
        {
            return element.CastAttributeToString(null, name);
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

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool? CastAttributeToBoolean(this XElement element, string name)
        {
            return element.CastAttributeToBoolean(null, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static bool? CastAttributeToBoolean(this XElement element, string nameSpace, string name)
        {
            var a = element.AttributeByNamespace(nameSpace, name);
            if (a == null)
            {
                return null;
            }

            bool x;
            if (Boolean.TryParse(a.Value, out x))
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int? CastAttributeToInt32(this XElement element, string name)
        {
            return element.CastAttributeToInt32(null, name);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static int? CastAttributeToInt32(this XElement element, string nameSpace, string name)
        {
            var a = element.AttributeByNamespace(nameSpace, name);
            if (a == null)
            {
                return null;
            }

            int x;
            if (Int32.TryParse(a.Value, out x))
            {
                return x;
            }
            return null;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static XElement AddXmlObject(this XDocument document, params RssXmlObject[] objects)
        {
            return document.AddXmlObject("", (IEnumerable<RssXmlObject>)objects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="nameSpace"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static XElement AddXmlObject(this XDocument document, XNamespace nameSpace, params RssXmlObject[] objects)
        {
            return document.AddXmlObject(nameSpace, (IEnumerable<RssXmlObject>)objects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="nameSpace"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static XElement AddXmlObject(this XDocument document, XNamespace nameSpace, IEnumerable<RssXmlObject> objects)
        {
            return document.Root.AddXmlObject(nameSpace, objects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static XElement AddXmlObject(this XElement element, params RssXmlObject[] objects)
        {
            return element.AddXmlObject("", (IEnumerable<RssXmlObject>) objects);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="objects"></param>
        /// <returns></returns>
        public static XElement AddXmlObject(this XElement element, XNamespace nameSpace, params RssXmlObject[] objects)
        {
            return element.AddXmlObject(nameSpace, (IEnumerable<RssXmlObject>)objects);
        }
        /// <summary>
        /// overload for Silverlight
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="items"></param>
        public static XElement AddXmlObject(this XElement element, XNamespace nameSpace, IEnumerable<RssItem> items)
        {
            List<RssXmlObject> l = new List<RssXmlObject>();
            foreach (var item in items)
            {
                l.Add(item as RssXmlObject);
            }
            return AddXmlObject(element, nameSpace, l);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="nameSpace"></param>
        /// <param name="objects"></param>
        public static XElement AddXmlObject(this XElement element, XNamespace nameSpace, IEnumerable<RssXmlObject> objects)
        {
            foreach (var obj in objects)
            {
                if (obj == null)
                {
                    continue;
                }

                var e = obj.CreateElement(nameSpace);
                if (e != null)
                {
                    element.Add(e);
                }
            }
            return element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="document"></param>
        /// <param name="addElement"></param>
        /// <returns></returns>
        public static XDocument AddElement(this XDocument document, XElement addElement)
        {
            document.Add(addElement);
            return document;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <returns></returns>
        public static XElement AddElement(this XElement element, XName name)
        {
            return element.AddElement(new XElement(name));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XElement AddElement(this XElement element, XName name, object value)
        {
            return element.AddElement(new XElement(name, value));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="addElement"></param>
        /// <returns></returns>
        public static XElement AddElement(this XElement element, XElement addElement)
        {
            element.Add(addElement);
            return element;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        /// <param name="name"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static XElement AddAttribute(this XElement element, XName name, object value)
        {
            element.Add(new XAttribute(name, value));
            return element;
        }
    }
}