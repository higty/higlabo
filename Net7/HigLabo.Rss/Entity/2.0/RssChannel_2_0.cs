using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    public class RssChannel_2_0 : RssChannel_0_92
    {
        public string Generator { get; set; } = "";
        public string TTL { get; set; } = "";

        public RssChannel_2_0()
        {
            
        }
        public RssChannel_2_0(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
            Generator = element.CastElementToString("generator") ?? "";
            TTL = element.CastElementToString("ttl") ?? "";
        }
    }
}