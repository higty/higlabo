using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssImage_0_92 : RssImage
    {
        public RssImage_0_92() {}
        public RssImage_0_92(XElement element)
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