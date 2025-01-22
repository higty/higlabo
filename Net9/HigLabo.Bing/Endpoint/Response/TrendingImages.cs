namespace HigLabo.Bing;

public class TrendingImages : BingRestApiResponse
{
    public ImageCategory[] Categories { get; set; } = Array.Empty<ImageCategory>();
}
