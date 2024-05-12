using System.Xml.Linq;
using HigLabo.Core;
using HigLabo.Rss.Internal;

namespace HigLabo.Rss
{
	public class RssItem_2_0 : RssItem_0_92
    {
        public string Author { get; set; } = "";
        public string Comments { get; set; } = "";
        public string Content { get; set; } = "";
        public RssGuid Guid { get; set; } = new();

        public RssItem_2_0()
        {

        }
        public RssItem_2_0(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
		protected new void Parse(XElement element)
        {
            Author = element.CastElementToString("author") ?? "";
            if (string.IsNullOrWhiteSpace(Author))
            {
                Author = element.CastElementToString("[author](dc:creator)") ?? "";
            }
            Comments = element.CastElementToString("comments") ?? "";

            var guid = element.ElementByNamespace("guid");
            if (guid != null)
            {
                Guid = new RssGuid(guid);
            }

            var contentEncoded = element.ElementByNamespace("content", "encoded");
            if (contentEncoded != null)
            {
                Content = element.CastElementToString("content", "encoded") ?? "";
            }

            this.PubDate = RssItem.ParsePubDate(element.CastElementToString("pubDate") ?? "");
        }
    }
}