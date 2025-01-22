using System;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class RssChannel : RssXmlObject
{
    public string Title { get; set; } = "";
    public string Link { get; set; } = "";
    public string Description { get; set; } = "";

    public RssChannel()
    {
    }
    public RssChannel(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Title = element.CastElementToString("title") ?? "";
        Link = element.CastElementToString("link") ?? "";
        Description = element.CastElementToString("description") ?? "";
    }
    public override XElement CreateElement(XNamespace xmlns)
    {
        return new XElement(xmlns + "channel")
            .AddElement(xmlns + "title", Title)
            .AddElement(xmlns + "link", Link)
            .AddElement(xmlns + "description", Description);
    }
}