using System;
using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssTextInput : RssXmlObject
{
    public string Title { get; set; } = "";
    public string Name { get; set; } = "";
    public string Link { get; set; } = "";
    public string Description { get; set; } = "";

    public RssTextInput()
    {
        
    }
    public RssTextInput(XElement element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected void Parse(XElement element)
    {
        Title = element.CastElementToString("title") ?? "";
        Name = element.CastElementToString("name") ?? "";
        Link = element.CastElementToString("link") ?? "";
        Description = element.CastElementToString("description") ?? "";
    }
    public override XElement CreateElement(XNamespace xmlns)
    {
        return new XElement(xmlns + "textinput",
            new XElement(xmlns + "title", Title),
            new XElement(xmlns + "name", Name),
            new XElement(xmlns + "link", Link),
            new XElement(xmlns + "description", Description)
        );
    }
}