using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssItem_0_91 : RssItem
    {
        /// <summary>
        /// 
        /// </summary>
        public RssItem_0_91()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem_0_91(XElement element)
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
            Description = element.CastElementToString("description");
        }
    }
}