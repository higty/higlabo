using System.Xml.Linq;

namespace HigLabo.Rss;

public class RssTextInput_0_90 : RssTextInput
{
    public RssTextInput_0_90()
    {
        
    }
    public RssTextInput_0_90(XElement element)
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