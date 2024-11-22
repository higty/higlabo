using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssItem_Atom : RssItem
{
    public string ID { get; set; } = "";
    public string Summary { get; set; } = "";
    public List<string> Authors { get; private set; } = new();

    public RssItem_Atom(XElement element)
        : base(element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected new void Parse(XElement element)
    {
        this.ID = element.CastElementToString("id") ?? "";
        this.PubDate = RssItem.ParseDate(element.CastElementToString("published") ?? "");
        this.Date = RssItem.ParseDate(element.CastElementToString("updated") ?? "");
        var author = element.ElementByNamespace("author");
        foreach (var name in author.ElementsByNamespace("name"))
        {
            this.Authors.Add(name.Value);
        }
        this.Link = element.ElementByNamespace("link").CastAttributeToString("href") ?? "";
        this.Summary = element.CastElementToString("summary") ?? "";
        this.Description = element.CastElementToString("content") ?? "";

        this.ParseChild(element);
    }
    private void ParseChild(XElement element)
    {
        foreach (var item in element.Elements())
        {
            if (item.Name == null || item.Name.LocalName == null) { continue; }
            this[item.Name.LocalName] = item.Value;
            this.ParseChild(item);
        }
    }
}
