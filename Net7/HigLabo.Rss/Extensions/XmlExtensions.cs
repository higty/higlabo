using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Linq;

namespace HigLabo.Rss.Internal
{
    internal static class XmlExtensions
    {
        public static XElement? AddXmlObject(this XDocument document, params RssXmlObject[] objects)
        {
            return document.AddXmlObject("", (IEnumerable<RssXmlObject>)objects);
        }
        public static XElement? AddXmlObject(this XDocument document, XNamespace nameSpace, params RssXmlObject[] objects)
        {
            return document.AddXmlObject(nameSpace, (IEnumerable<RssXmlObject>)objects);
        }
        public static XElement? AddXmlObject(this XDocument document, XNamespace nameSpace, IEnumerable<RssXmlObject> objects)
        {
            return document.Root?.AddXmlObject(nameSpace, objects);
        }
        public static XElement AddXmlObject(this XElement element, params RssXmlObject[] objects)
        {
            return element.AddXmlObject("", (IEnumerable<RssXmlObject>) objects);
        }

        public static XElement AddXmlObject(this XElement element, XNamespace nameSpace, params RssXmlObject[] objects)
        {
            return element.AddXmlObject(nameSpace, (IEnumerable<RssXmlObject>)objects);
        }
        public static XElement AddXmlObject(this XElement element, XNamespace nameSpace, IEnumerable<RssItem> items)
        {
            List<RssXmlObject> l = new List<RssXmlObject>();
            foreach (var item in items)
            {
                l.Add(item as RssXmlObject);
            }
            return AddXmlObject(element, nameSpace, l);
        }
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

        public static XDocument AddElement(this XDocument document, XElement addElement)
        {
            document.Add(addElement);
            return document;
        }
        public static XElement AddElement(this XElement element, XName name)
        {
            return element.AddElement(new XElement(name));
        }
        public static XElement AddElement(this XElement element, XName name, object value)
        {
            return element.AddElement(new XElement(name, value));
        }
        public static XElement AddElement(this XElement element, XElement addElement)
        {
            element.Add(addElement);
            return element;
        }
        public static XElement AddAttribute(this XElement element, XName name, object value)
        {
            element.Add(new XAttribute(name, value));
            return element;
        }
    }
}