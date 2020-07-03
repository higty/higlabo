using System;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssChannel : RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
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
        public RssChannel()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel(XElement element)
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
            return new XElement(xmlns + "channel")
                .AddElement(xmlns + "title", Title)
                .AddElement(xmlns + "link", Link)
                .AddElement(xmlns + "description", Description);
        }
    }
}