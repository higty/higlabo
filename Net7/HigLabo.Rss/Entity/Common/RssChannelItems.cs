using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    public class RssChannelItems : RssXmlObject
    {
        public IList<RssResource> Resources { get; set; } = new List<RssResource>();

        public RssChannelItems()
        {
        }
        public RssChannelItems(XElement element)
        {
            Resources = new List<RssResource>();
            if (element != null)
            {
                Parse(element);
            }
        }
        protected void Parse(XElement element)
        {
            var seq = element.ElementByNamespace("rdf", "Seq");
            foreach (var li in seq.ElementsByNamespace("rdf", "li"))
            {
                Resources.Add(new RssResource(RssNamespace.RDF + "li", li.CastAttributeToString("resource") ?? ""));
            }
        }
        public override XElement CreateElement(XNamespace xmlns)
        {
            var rdf = RssNamespace.RDF;

            var seq = new XElement(rdf + "Seq");
            foreach (var r in Resources)
            {
                seq.AddElement(new XElement(r.ElementName)
                    .AddAttribute("resource", r.Resource));
            }
            var element = new XElement(xmlns + "items")
                .AddElement(seq);

            return element;
        }
    }
}