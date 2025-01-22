using System.Collections.Generic;
using System.Diagnostics.Metrics;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class RssChannel_1_0 : RssChannel_0_90
{
    public string About { get; set; } = "";
    public RssResource? Image { get; set; } 
    public RssChannelItems? Items { get; set; } 
    public RssResource? TextInput { get; set; } 

    public RssChannel_1_0(XElement element)
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

        var image = element.ElementByNamespace("image");
        if (image != null)
        {
            Image = new RssResource(RssNamespace.RDF + "image", image.CastAttributeToString("rdf", "resource") ?? "");
        }

        var items = element.ElementByNamespace("items");
        if (items != null)
        {
            Items = new RssChannelItems(items);
        }

        var textInput = element.ElementByNamespace("textinput");
        if (textInput != null)
        {
            TextInput = new RssResource(RssNamespace.RDF + "textinput", textInput.CastAttributeToString("rdf", "resource") ?? "");
        }
    }
    public override XElement CreateElement(XNamespace xmlns)
    {
        var xml = base.CreateElement(xmlns).AddAttribute(RssNamespace.RDF + "about", About);

        if (Image != null)
        {
            xml.AddXmlObject(Image);
        }
        if (Items != null)
        {
            xml.AddXmlObject(Items);
        }
        if (TextInput != null)
        {
            xml.AddXmlObject(TextInput);
        }
        return xml;
    }
}