using HigLabo.RestApi;
using System.Reflection.Metadata;

namespace HigLabo.Bing;

public class VideosTrendingParameter : BingRestApiParameter
{
    public override string HttpMethod => "GET";

    public override string GetApiPath()
    {
        return $"/videos/trending";
    }
    public override string GetQueryString()
    {
        return $"mkt={this.Market.GetMarketCode()}";
    }
}
public partial class BingClient
{
    public async ValueTask<TrendingVideos> TrendingVideos(VideosTrendingParameter parameter)
    {
        return await this.SendJsonAsync<VideosTrendingParameter, TrendingVideos>(parameter);
    }
}
