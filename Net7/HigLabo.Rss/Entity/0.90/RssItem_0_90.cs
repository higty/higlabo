using System.Xml.Linq;

namespace HigLabo.Rss
{
    public class RssItem_0_90 : RssItem
    {
        public RssItem_0_90()
        {
        }
        public RssItem_0_90(XElement element)
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