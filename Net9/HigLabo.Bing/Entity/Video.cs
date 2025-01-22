using HigLabo.Core;

namespace HigLabo.Bing;

public class Video
{
    public bool AllowHttpsEmbed { get; set; }
    public bool AllowMobileEmbed { get; set; }
    public Publisher? Creator { get; set; }
    public string ContentUrl { get; set; } = "";
    public string DatePublished { get; set; } = "";
    public DateTimeOffset? PublishTime
    {
        get
        {
            return this.DatePublished.ToDateTimeOffset();
        }
    }
    public string Description { get; set; } = "";
    public string Duration { get; set; } = "";
    public string EmbedHtml { get; set; } = "";
    public string EncodingFormat { get; set; } = "";
    public int? Height { get; set; }
    public string HostPageDisplayUrl { get; set; } = "";
    public string HostPageUrl { get; set; } = "";
    public string Id { get; set; } = "";
    public bool? IsAccessibleForFree { get; set; }
    public bool IsSuperFresh { get; set; }
    public Thing? MainEntity { get; set; }
    public string MotionThumbnailUrl { get; set; } = "";
    public string Name { get; set; } = "";
    public Publisher[]? Publisher { get; set; }
    public MediaSize? Thumbnail { get; set; }
    public string ThumbnailUrl { get; set; } = "";
    public string VideoId { get; set; } = "";
    public int? ViewCount { get; set; }
    public string WebSearchUrl { get; set; } = "";
    public int? Width { get; set; }

    public override string ToString()
    {
        return this.Name;
    }
}
