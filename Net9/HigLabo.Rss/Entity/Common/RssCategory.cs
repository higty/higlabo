using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssCategory
{
    public string Title { get; set; } = "";
    public string Domain { get; set; } = "";

    public RssCategory()
    {

    }
    public RssCategory(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Title = element.Value;
        Domain = element.CastAttributeToString("domain") ?? "";
    }
}