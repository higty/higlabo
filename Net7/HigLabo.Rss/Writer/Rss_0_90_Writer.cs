using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class Rss_0_90_Writer : RssWriter
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

            var ns = RssNamespace._0_90;
            var rdf = RssNamespace.RDF;

            return doc.AddElement(new XElement(rdf + "RDF")
                .AddAttribute("xmlns", ns)
                .AddAttribute(XNamespace.Xmlns + "rdf", rdf)
                .AddXmlObject(ns, rssFeed.Channel, rssFeed.Image)
                .AddXmlObject(ns, rssFeed.Items)
                .AddXmlObject(ns, rssFeed.TextInput));
        }
    }
}
