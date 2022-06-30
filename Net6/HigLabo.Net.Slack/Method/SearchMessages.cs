
namespace HigLabo.Net.Slack
{
    public partial class SearchMessagesParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "search.messages";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Query { get; set; }
        public int? Count { get; set; }
        public string Cursor { get; set; }
        public bool? Highlight { get; set; }
        public int? Page { get; set; }
        public Sort Sort { get; set; }
        public SortDirection Sort_Dir { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class SearchMessagesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<SearchMessagesResponse> SearchMessagesAsync(string query)
        {
            var p = new SearchMessagesParameter();
            p.Query = query;
            return await this.SendAsync<SearchMessagesParameter, SearchMessagesResponse>(p, CancellationToken.None);
        }
        public async Task<SearchMessagesResponse> SearchMessagesAsync(string query, CancellationToken cancellationToken)
        {
            var p = new SearchMessagesParameter();
            p.Query = query;
            return await this.SendAsync<SearchMessagesParameter, SearchMessagesResponse>(p, cancellationToken);
        }
        public async Task<SearchMessagesResponse> SearchMessagesAsync(SearchMessagesParameter parameter)
        {
            return await this.SendAsync<SearchMessagesParameter, SearchMessagesResponse>(parameter, CancellationToken.None);
        }
        public async Task<SearchMessagesResponse> SearchMessagesAsync(SearchMessagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SearchMessagesParameter, SearchMessagesResponse>(parameter, cancellationToken);
        }
        public async Task<List<SearchMessagesResponse>> SearchMessagesAsync(string query, PagingContext<SearchMessagesResponse> context)
        {
            var p = new SearchMessagesParameter();
            p.Query = query;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<SearchMessagesResponse>> SearchMessagesAsync(string query, PagingContext<SearchMessagesResponse> context, CancellationToken cancellationToken)
        {
            var p = new SearchMessagesParameter();
            p.Query = query;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<SearchMessagesResponse>> SearchMessagesAsync(SearchMessagesParameter parameter, PagingContext<SearchMessagesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<SearchMessagesResponse>> SearchMessagesAsync(SearchMessagesParameter parameter, PagingContext<SearchMessagesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
