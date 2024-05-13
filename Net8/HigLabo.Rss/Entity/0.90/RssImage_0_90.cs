using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssImage_0_90 : RssImage
    {
        public RssImage_0_90()
        {
            
        }
        public RssImage_0_90(XElement element)
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