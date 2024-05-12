using System.Xml.Linq;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssTextInput_2_0 : RssTextInput_0_92
    {
        /// <summary>
        /// 
        /// </summary>
        public RssTextInput_2_0()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssTextInput_2_0(XElement element)
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