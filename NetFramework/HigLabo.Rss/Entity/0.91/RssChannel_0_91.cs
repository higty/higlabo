using System.Xml.Linq;
using HigLabo.Core;

namespace HigLabo.Rss
{
    /// <summary>
    /// 
    /// </summary>
    public class RssChannel_0_91 : RssChannel
    {
        /// <summary>
        /// 
        /// </summary>
        public string Language { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Copyright { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Docs { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string LastBuildDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string ManagingEditor { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string PubDate { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string Rating { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SkipHours { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string SkipDays { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public string WebMaster { get; set; }

        /// <summary>
        /// 
        /// </summary>
        public RssChannel_0_91() {}

        /// <summary>
        /// 
        /// </summary>
        /// <param name="element"></param>
        public RssChannel_0_91(XElement element)
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
            Language = element.CastElementToString("language");
            Copyright = element.CastElementToString("copyright");
            Docs = element.CastElementToString("docs");
            LastBuildDate = element.CastElementToString("lastBuildDate");
            ManagingEditor = element.CastElementToString("managingEditor");
            PubDate = element.CastElementToString("pubDate");
            Rating = element.CastElementToString("rating");
            SkipHours = element.CastElementToString("skipHours");
            SkipDays = element.CastElementToString("skipDays");
            WebMaster = element.CastElementToString("webMaster");
        }
    }
}