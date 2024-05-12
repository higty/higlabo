using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class Rss_0_91_Writer : RssWriter
    {
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string Write(RssFeed rssFeed)
        {
            var doc = CreateDocument(rssFeed);
            return String.Format("{0}{1}{2}", doc.Declaration, Environment.NewLine, doc);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        protected XDocument CreateDocument(RssFeed rssFeed)
        {
            var doc = new XDocument(new XDeclaration("1.0", "utf-8", null));

            return doc.AddElement(
                new XElement("rss")
                    .AddAttribute("version", "0.91")
                    .AddElement(rssFeed.Channel.CreateElement("")
                        .AddXmlObject("", rssFeed.Image)
                        .AddXmlObject("", rssFeed.Items)
                        .AddXmlObject("", rssFeed.TextInput)));
        }
    }
}
