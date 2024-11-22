namespace HigLabo.Bing;

public class VideoDetails : BingRestApiResponse
{
    public VideosModule? RelatedVideos { get; set; }
    public Video VideoResult { get; set; } = new();
}
