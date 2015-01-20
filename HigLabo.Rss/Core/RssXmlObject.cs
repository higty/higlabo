using System.Xml.Linq;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public abstract class RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public abstract XElement CreateElement(XNamespace xmlns);
    }
}