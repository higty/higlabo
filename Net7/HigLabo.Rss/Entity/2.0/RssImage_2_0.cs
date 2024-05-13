using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssImage_2_0 : RssImage_0_92
    {
        public RssImage_2_0()
        {
            
        }
        public RssImage_2_0(XElement element)
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
}