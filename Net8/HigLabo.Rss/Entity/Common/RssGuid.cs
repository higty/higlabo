using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssGuid
{
    public string ID { get; set; } = "";
    public bool? IsPermaLink { get; set; }

    public RssGuid()
    {
        
    }
    public RssGuid(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        ID = element.Value;
        if (bool.TryParse(element.CastAttributeToString("isPermaLink"), out var bl))
        {
            this.IsPermaLink = bl;
        }
    }
}