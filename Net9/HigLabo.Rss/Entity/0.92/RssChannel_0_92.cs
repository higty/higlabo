using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss;

public class RssChannel_0_92 : RssChannel_0_91
{
    public RssCloud Cloud { get; set; } = new();

    public RssChannel_0_92()
    {
        
    }
    public RssChannel_0_92(XElement element)
        : base(element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected new void Parse(XElement element)
    {
        var cloud = element.ElementByNamespace("cloud");
        if (cloud != null)
        {
            Cloud = new RssCloud(cloud);
        }
    }
}