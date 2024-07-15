using HigLabo.Core;

namespace HigLabo.Bing
{
    public class Image
    {
        public string AccentColor { get; set; } = "";
        public string ContentSize { get; set; } = "";
        public string ContentUrl { get; set; } = "";
        public string CreativeCommons { get; set; } = "";
        public string DatePublished { get; set; } = "";
        public DateTimeOffset? PublishTime
        {
            get
            {
                return this.DatePublished.ToDateTimeOffset();
            }
        }
        public string EncodingFormat { get; set; } = "";
        public int? Height { get; set; }
        public string HostPageDisplayUrl { get; set; } = "";
        public string HostPageDomainFriendlyName { get; set; } = "";
        public string HostPageUrl { get; set; } = "";
        public string Id { get; set; } = "";
        public string ImageId { get; set; } = "";
        public InsightsMetadata? InsightsMetadata { get; set; }
        public string Name { get; set; } = "";
        public MediaSize? Thumbnail { get; set; }
        public string ThumbnailUrl { get; set; } = "";
        public string WebSearchUrl { get; set; } = "";
        public int? Width { get; set; }

        public override string ToString()
        {
            return this.Name;
        }
    }
}
