using System;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class RssImage : RssXmlObject
    {
        public string Title { get; set; } = "";
        public string Url { get; set; } = "";
        public string Link { get; set; } = "";

        public RssImage()
        {
        }
        public RssImage(XElement element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected void Parse(XElement element)
        {
            Title = element.CastElementToString("title") ?? "";
            Url = element.CastElementToString("url") ?? "";
            Link = element.CastElementToString("link") ?? "";
        }
        public override XElement CreateElement(XNamespace xmlns)
        {
            return new XElement(xmlns + "image")
                .AddElement(xmlns + "title", Title)
                .AddElement(xmlns + "url", Url)
                .AddElement(xmlns + "link", Link);
        }
    }
}