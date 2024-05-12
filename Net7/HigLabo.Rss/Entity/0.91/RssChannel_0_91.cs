using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    public class RssChannel_0_91 : RssChannel
    {
        public string Language { get; set; } = "";
        public string Copyright { get; set; } = "";
        public string Docs { get; set; } = "";
        public string LastBuildDate { get; set; } = "";
        public string ManagingEditor { get; set; } = "";
        public string PubDate { get; set; } = "";
        public string Rating { get; set; } = "";
        public string SkipHours { get; set; } = "";
        public string SkipDays { get; set; } = "";
        public string WebMaster { get; set; } = "";

        public RssChannel_0_91() { }
        public RssChannel_0_91(XElement element)
            : base(element)
        {
            if (element != null)
            {
                Parse(element);
            }
        }
        protected new void Parse(XElement element)
        {
            Language = element.CastElementToString("language") ?? "";
            Copyright = element.CastElementToString("copyright") ?? "";
            Docs = element.CastElementToString("docs") ?? "";
            LastBuildDate = element.CastElementToString("lastBuildDate") ?? "";
            ManagingEditor = element.CastElementToString("managingEditor") ?? "";
            PubDate = element.CastElementToString("pubDate") ?? "";
            Rating = element.CastElementToString("rating") ?? "";
            SkipHours = element.CastElementToString("skipHours") ?? "";
            SkipDays = element.CastElementToString("skipDays") ?? "";
            WebMaster = element.CastElementToString("webMaster") ?? "";
        }
    }
}