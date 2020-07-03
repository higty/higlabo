using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssChannel_2_0 : RssChannel_0_92
    {
        /// <summary>
        /// 
        /// </summary>
        public string Generator { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string TTL { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssChannel_2_0()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel_2_0(XElement element)
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
            Generator = element.CastElementToString("generator");
            TTL = element.CastElementToString("ttl");
        }
    }
}