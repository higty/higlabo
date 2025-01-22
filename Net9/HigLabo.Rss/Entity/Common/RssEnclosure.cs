using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssEnclosure
{
    public string Url { get; set; } = "";
    public string Length { get; set; } = "";
    public string Type { get; set; } = "";

    public RssEnclosure()
    {
        
    }
    public RssEnclosure(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Url = element.CastAttributeToString("url") ?? "";
        Length = element.CastAttributeToString("length") ?? "";
        Type = element.CastAttributeToString("type") ?? "";
    }
    public override string ToString()
    {
        return string.Format("Url: {0}, Length: {1}, Type: {2}", Url, Length, Type);
    }
}