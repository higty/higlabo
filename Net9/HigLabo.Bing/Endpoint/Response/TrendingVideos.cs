namespace HigLabo.Bing;

public class TrendingVideos : BingRestApiResponse
{
    public VideoTile[] BannerTiles { get; set; } = Array.Empty<VideoTile>();
    public VideoCategory[] Categories { get; set; } = Array.Empty<VideoCategory>();
}
