using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class RssFeed
{
    public RssVersion Version { get; set; } = new();
    public RssChannel Channel { get; set; } = new();
    public RssImage Image { get; set; } = new();
    public List<RssItem> Items { get; private set; } = new List<RssItem>();
    public RssTextInput TextInput { get; set; } = new();

    public RssFeed()
    {
    }
    public static RssFeed Parse(String xml)
    {
        XDocument? doc = null;
        try
        {
            doc = XDocument.Parse(xml);
        }
        catch
        {
            throw new RssParseException(xml);
        }
        var root = doc.Root;
        if (root == null) { throw new RssParseException(xml); }
        var version = ParseVersion(root);
        if (version.HasValue == false) { throw new RssParseException(xml); }

        if (version.Value == RssVersion.Atom)
        {
            var parser = new AtomParser();
            return parser.Parse(xml);
        }
        else
        {
            var parser = RssParser.Create(version.Value);
            return parser.Parse(xml);
        }
    }
    private static RssVersion? ParseVersion(XElement element)
    {
        element.CastAttributeToString("version");
        var ver = element.Attribute("version");
        if (ver != null)
        {
            //0.91, 0.92, 2.0
            return CreateRssVersion(ver.Value);
        }

        var ns = element.GetDefaultNamespace();
        if (ns.NamespaceName.ToLower().Contains("netscape")) return RssVersion.Rss_0_90;
        if (ns.NamespaceName.ToLower().Contains("purl.org")) return RssVersion.Rss_1_0;
        if (ns.NamespaceName.ToLower().Contains("atom")) return RssVersion.Atom;

        return null;
    }
    private static RssVersion? CreateRssVersion(String value)
    {
        switch (value)
        {
            case "0.9": return RssVersion.Rss_0_90;
            case "0.91": return RssVersion.Rss_0_91;
            case "0.92": return RssVersion.Rss_0_92;
            case "1.0": return RssVersion.Rss_1_0;
            case "2.0": return RssVersion.Rss_2_0;
            case "atom": return RssVersion.Atom;
            default: return null;
        }
    }
    public string Write()
    {
        var writer = RssWriter.Create(this.Version);
        return writer.Write(this);
    }
}