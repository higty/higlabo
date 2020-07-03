using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssItem_1_0 : RssItem_0_90
    {
        /// <summary>
        /// 
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssItem_1_0()
        {
            
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem_1_0(XElement element)
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
        /// <returns></returns>
        protected new void Parse(XElement element)
        {
            About = element.CastAttributeToString("rdf", "about");
            Description = element.CastElementToString("description");
            this.Date = RssItem.ParseDate(element.CastElementToString("dc", "date"));
        }
    }
}