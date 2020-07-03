using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssTextInput_1_0 : RssTextInput_0_90
    {
        /// <summary>
        /// 
        /// </summary>
        public string About { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssTextInput_1_0()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssTextInput_1_0(XElement element)
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
        }
    }
}