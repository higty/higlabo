using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssTextInput_1_0 : RssTextInput_0_90
{
    public string About { get; set; } = "";

    public RssTextInput_1_0()
    {
        
    }
    public RssTextInput_1_0(XElement element)
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