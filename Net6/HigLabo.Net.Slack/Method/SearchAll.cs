
namespace HigLabo.Net.Slack
{
    public partial class SearchAllParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "search.all";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Query { get; set; }
        public int? Count { get; set; }
        public bool? Highlight { get; set; }
        public int? Page { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class SearchAllResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<SearchAllResponse> SearchAllAsync(string query)
        {
            var p = new SearchAllParameter();
            p.Query = query;
            return await this.SendAsync<SearchAllParameter, SearchAllResponse>(p, CancellationToken.None);
        }
        public async Task<SearchAllResponse> SearchAllAsync(string query, CancellationToken cancellationToken)
        {
            var p = new SearchAllParameter();
            p.Query = query;
            return await this.SendAsync<SearchAllParameter, SearchAllResponse>(p, cancellationToken);
        }
        public async Task<SearchAllResponse> SearchAllAsync(SearchAllParameter parameter)
        {
            return await this.SendAsync<SearchAllParameter, SearchAllResponse>(parameter, CancellationToken.None);
        }
        public async Task<SearchAllResponse> SearchAllAsync(SearchAllParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchAllParameter, SearchAllResponse>(parameter, cancellationToken);
        }
    }
}
