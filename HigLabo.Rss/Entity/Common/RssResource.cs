using System.Xml.Linq;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssResource : RssXmlObject
    {
        /// <summary>
        /// 
        /// </summary>
        public XName ElementName { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Resource { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssResource()
        {
            
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="elementName"></param>
        /// <param name="resource"></param>
        public RssResource(XName elementName, string resource)
        {
            ElementName = elementName;
            Resource = resource;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlns"></param>
        /// <returns></returns>
        public override XElement CreateElement(XNamespace xmlns)
        {
            return new XElement(ElementName)
                .AddAttribute(RssNamespace.RDF + "resource", Resource);
        }
    }
}