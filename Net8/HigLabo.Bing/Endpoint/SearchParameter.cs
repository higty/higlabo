using HigLabo.RestApi;

namespace HigLabo.Bing
{
    public class SearchParameter : BingRestApiParameter
    {
        public override string HttpMethod => "GET";

        public override string GetApiPath()
        {
            return $"/search";
        }
    }
    public partial class BingClient
    {
        public async ValueTask<SearchResponse> Search(string queryText)
        {
            var p = new SearchParameter();
            p.Q = queryText;
            return await this.Search(p);
        }
        public async ValueTask<SearchResponse> Search(SearchParameter parameter)
        {
            return await this.SendJsonAsync<SearchParameter, SearchResponse>(parameter);
        }
    }
}
