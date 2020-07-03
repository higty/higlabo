using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssChannel_0_92 : RssChannel_0_91
    {
        /// <summary>
        /// 
        /// </summary>
        public RssCloud Cloud { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssChannel_0_92()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel_0_92(XElement element)
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
            var cloud = element.ElementByNamespace("cloud");
            if (cloud != null)
            {
                Cloud = new RssCloud(cloud);
            }
        }
    }
}