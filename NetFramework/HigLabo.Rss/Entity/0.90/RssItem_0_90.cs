using System.Xml.Linq;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssItem_0_90 : RssItem
    {
        /// <summary>
        /// 
        /// </summary>
        public RssItem_0_90()
        {
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem_0_90(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        protected new void Parse(XElement element)
        {
        }
    }
}