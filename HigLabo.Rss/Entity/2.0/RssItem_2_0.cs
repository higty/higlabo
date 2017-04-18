using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
	public class RssItem_2_0 : RssItem_0_92
    {
        /// <summary>
        /// 
        /// </summary>
        public string Author { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public string Comments { get; set; }
        public string Content { get; set; }
        /// <summary>
        /// 
        /// </summary>
        public RssGuid Guid { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssItem_2_0()
        {

        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssItem_2_0(XElement element)
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
            Author = element.CastElementToString("author");
            Comments = element.CastElementToString("comments");

            var guid = element.ElementByNamespace("guid");
            if (guid != null)
            {
                Guid = new RssGuid(guid);
            }

            var contentEncoded = element.ElementByNamespace("content", "encoded");
            if (contentEncoded != null)
            {
                Content = element.CastElementToString("content", "encoded");
            }

            this.PubDate = RssItem.ParsePubDate(element.CastElementToString("pubDate"));
        }
    }
}