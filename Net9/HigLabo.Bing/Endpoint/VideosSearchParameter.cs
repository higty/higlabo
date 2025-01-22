using HigLabo.RestApi;

namespace HigLabo.Bing;

public class VideosSearchParameter : BingRestApiParameter
{
    public override string HttpMethod => "GET";

    public override string GetApiPath()
    {
        return $"/videos/search";
    }
}
public partial class BingClient
{
    public async ValueTask<VideosAnswer> SearchVideos(string queryText)
    {
        var p = new VideosSearchParameter();
        p.Q = queryText;
        return await this.SearchVideos(p);
    }
    public async ValueTask<VideosAnswer> SearchVideos(VideosSearchParameter parameter)
    {
        return await this.SendJsonAsync<VideosSearchParameter, VideosAnswer>(parameter);
    }
}
