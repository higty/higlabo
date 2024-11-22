using System.Xml.Linq;

namespace HigLabo.Rss;

public class RssChannel_0_90 : RssChannel
{
    public RssChannel_0_90()
    {
        
    }
    public RssChannel_0_90(XElement element)
        : base(element)
    {
        if (element != null)
        {
            Parse(element);
        }
    }
    protected new void Parse(XElement element)
    {
        
    }
}