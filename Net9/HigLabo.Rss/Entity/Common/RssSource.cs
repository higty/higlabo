using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssSource
{
    public string Title { get; set; } = "";
    public string Url { get; set; } = "";

    public RssSource()
    {
        
    }
    public RssSource(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Title = element.Value;
        Url = element.CastAttributeToString("url") ?? "";
    }
}