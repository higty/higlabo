using System;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssImage : RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Link { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RssImage()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssImage(XElement element)
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
            Url = element.CastElementToString("url");
            Link = element.CastElementToString("link");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public override XElement CreateElement(XNamespace xmlns)
        {
            return new XElement(xmlns + "image")
                .AddElement(xmlns + "title", Title)
                .AddElement(xmlns + "url", Url)
                .AddElement(xmlns + "link", Link);
        }
    }
}