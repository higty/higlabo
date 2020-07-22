using System;
using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssTextInput : RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Description { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RssTextInput()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssTextInput(XElement element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        protected void Parse(XElement element)
        {
            Title = element.CastElementToString("title");
            Name = element.CastElementToString("name");   
            Link = element.CastElementToString("link");   
            Description = element.CastElementToString("description");   
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public override XElement CreateElement(XNamespace xmlns)
        {
            return new XElement(xmlns + "textinput",
                new XElement(xmlns + "title", Title),
                new XElement(xmlns + "name", Name),
                new XElement(xmlns + "link", Link),
                new XElement(xmlns + "description", Description)
            );
        }
    }
}