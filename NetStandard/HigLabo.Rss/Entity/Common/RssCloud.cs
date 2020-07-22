using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssCloud
    {
        /// <summary>
        /// 
        /// </summary>
        public string Domain { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Port { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Path { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string RegisterProcedure { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Protocol { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssCloud()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssCloud(XElement element)
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
            Domain = element.CastAttributeToString("domain");
            Port = element.CastAttributeToString("port");
            Path = element.CastAttributeToString("path");
            RegisterProcedure = element.CastAttributeToString("registerProcedure");
            Protocol = element.CastAttributeToString("protocol");
        }
    }
}