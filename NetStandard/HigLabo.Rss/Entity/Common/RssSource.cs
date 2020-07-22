using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssSource
    {
        /// <summary>
        /// 
        /// </summary>
        public string Title { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Url { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssSource()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssSource(XElement element)
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
        protected void Parse(XElement element)
        {
            Title = element.Value;
            Url = element.CastAttributeToString("url");
        }
    }
}