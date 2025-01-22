using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssItem_0_91 : RssItem
{
    public RssItem_0_91()
    {
        
    }
    public RssItem_0_91(XElement element)
        : base(element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected new void Parse(XElement element)
    {
        Description = element.CastElementToString("description") ?? "";
    }
}