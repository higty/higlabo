using System.Xml.Linq;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssTextInput_0_92 : RssTextInput_0_91
    {
        /// <summary>
        /// 
        /// </summary>
        public RssTextInput_0_92()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssTextInput_0_92(XElement element)
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