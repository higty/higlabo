using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssImage_1_0 : RssImage_0_90
{
    public string About { get; set; } = "";

    public RssImage_1_0()
    {
        
    }
    public RssImage_1_0(XElement element)
        : base(element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected new void Parse(XElement element)
    {
        About = element.CastAttributeToString("rdf", "about") ?? "";
    }
}