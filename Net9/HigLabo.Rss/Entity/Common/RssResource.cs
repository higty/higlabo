using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class RssResource : RssXmlObject
{
    public XName ElementName { get; set; } 
    public string Resource { get; set; } = "";

    public RssResource(XName elementName, string resource)
    {
        ElementName = elementName;
        Resource = resource;
    }
    public override XElement CreateElement(XNamespace xmlns)
    {
        return new XElement(ElementName)
            .AddAttribute(RssNamespace.RDF + "resource", Resource);
    }
}