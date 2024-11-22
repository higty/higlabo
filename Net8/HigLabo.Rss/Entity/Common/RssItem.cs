using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss;

public class RssItem : RssXmlObject
{
    public string Title { get; set; } = "";
    public string Link { get; set; } = "";
    public DateTimeOffset? PubDate { get; set; }
    public DateTimeOffset? Date { get; set; }
    public string Description { get; set; } = "";
    
    public RssItem()
    {
        
    }
    public RssItem(XElement element)
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
    }
    public static DateTimeOffset? ParsePubDate(String pubDate)
    {
        DateTimeOffset dtime = DateTimeOffset.MinValue;
        if (String.IsNullOrEmpty(pubDate) == true) { return null; }
        if (DateTimeOffset.TryParse(pubDate, out dtime) == true)
        {
            return dtime;
        }
        else
        {
            String tmp = pubDate;
            tmp = tmp.Substring(0, tmp.Length - 5);
            tmp += "GMT";
            if (DateTimeOffset.TryParse(tmp, out dtime) == true)
            {
                return dtime;
            }
        }
        return null;
    }
    public static DateTimeOffset? ParseDate(String date)
    {
        DateTimeOffset dtime = DateTimeOffset.MinValue;
        if (String.IsNullOrEmpty(date) == true) { return null; }
        if (DateTimeOffset.TryParse(date, out dtime) == true)
        {
            return dtime;
        }
        else
        {
            String tmp = date;
            tmp = tmp.Substring(0, tmp.Length - 6);
            tmp += "Z";
            if (DateTimeOffset.TryParse(tmp, out dtime) == true)
            {
                return dtime;
            }
        }
        return null;
    }
    public override string ToString()
    {
        return $"Title: {Title}\r\nLink: {Link}";
    }
    public override XElement CreateElement(XNamespace xmlns)
    {
        return new XElement(xmlns + "item")
            .AddElement(xmlns + "title", Title)
            .AddElement(xmlns + "link", Link);
    }
}