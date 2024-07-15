using HigLabo.RestApi;

namespace HigLabo.Bing
{
    public class NewsSearchParameter : BingRestApiParameter
    {
        public override string HttpMethod => "GET";

        public override string GetApiPath()
        {
            return $"/news/search";
        }
    }
    public partial class BingClient
    {
        public async ValueTask<NewsAnswer> SearchNews(string queryText)
        {
            var p = new NewsSearchParameter();
            p.Q = queryText;
            return await this.SearchNews(p);
        }
        public async ValueTask<NewsAnswer> SearchNews(NewsSearchParameter parameter)
        {
            return await this.SendJsonAsync<NewsSearchParameter, NewsAnswer>(parameter);
        }
    }
}
