
namespace HigLabo.Net.Slack
{
    public class ReactionsListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "reactions.list";
        public string HttpMethod { get; private set; } = "GET";
        public int? Count { get; set; }
        public string Cursor { get; set; } = "";
        public bool? Full { get; set; }
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string Team_Id { get; set; } = "";
        public string User { get; set; } = "";
    }
    public partial class ReactionsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ReactionsListResponse> ReactionsListAsync()
        {
            var p = new ReactionsListParameter();
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(p, CancellationToken.None);
        }
        public async Task<ReactionsListResponse> ReactionsListAsync(CancellationToken cancellationToken)
        {
            var p = new ReactionsListParameter();
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(p, cancellationToken);
        }
        public async Task<ReactionsListResponse> ReactionsListAsync(ReactionsListParameter parameter)
        {
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<ReactionsListResponse> ReactionsListAsync(ReactionsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(PagingContext<ReactionsListResponse> context)
        {
            var p = new ReactionsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(CancellationToken cancellationToken, PagingContext<ReactionsListResponse> context)
        {
            var p = new ReactionsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(ReactionsListParameter parameter, PagingContext<ReactionsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(ReactionsListParameter parameter, PagingContext<ReactionsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
