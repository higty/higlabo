using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class AtomParser : IRssParser
{
    public RssFeed Parse(String xml)
    {
        var feed = new RssFeed();
        var doc = XDocument.Parse(xml);
        var element = doc.Root;
        if (element == null) { throw new InvalidOperationException("xml is invalid."); }
        feed.Channel = new RssChannel_Atom(element);

        var image = element.ElementByNamespace("image");
        if (image == null)
        {
            var channel = element.ElementByNamespace("channel");
            if (channel != null)
            {
                image = channel.ElementByNamespace("image");
            }
        }
        if (image != null)
        {
            feed.Image = new RssImage_Atom(image);
        }

        foreach (var item in element.ElementsByNamespace("entry"))
        {
            feed.Items.Add(new RssItem_Atom(item));
        }

        var textInput = element.ElementByNamespace("textinput");
        if (textInput == null)
        {
            var channel = element.ElementByNamespace("channel");
            if (channel != null)
            {
                textInput = channel.ElementByNamespace("textinput");
            }
        }
        if (textInput != null)
        {
            feed.TextInput = new RssTextInput_Atom(textInput);
        }
        return feed;
    }
}
