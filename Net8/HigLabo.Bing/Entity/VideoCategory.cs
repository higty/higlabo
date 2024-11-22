namespace HigLabo.Bing;

public class VideoCategory
{
    public string Title { get; set; } = "";
    public VideoTile[] SubCategories { get; set; } = Array.Empty<VideoTile>();
}
