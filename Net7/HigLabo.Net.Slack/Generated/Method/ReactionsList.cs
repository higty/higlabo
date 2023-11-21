using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/reactions.list
    /// </summary>
    public partial class ReactionsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "reactions.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public int? Count { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public bool? Full { get; set; }
        public int? Limit { get; set; }
        public int? Page { get; set; }
        public string? Team_Id { get; set; }
        public string? User { get; set; }
    }
    public partial class ReactionsListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/reactions.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<ReactionsListResponse> ReactionsListAsync()
        {
            var p = new ReactionsListParameter();
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<ReactionsListResponse> ReactionsListAsync(CancellationToken cancellationToken)
        {
            var p = new ReactionsListParameter();
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<ReactionsListResponse> ReactionsListAsync(ReactionsListParameter parameter)
        {
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<ReactionsListResponse> ReactionsListAsync(ReactionsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ReactionsListParameter, ReactionsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(PagingContext<ReactionsListResponse> context)
        {
            var p = new ReactionsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async Task<List<ReactionsListResponse>> ReactionsListAsync(CancellationToken cancellationToken, PagingContext<ReactionsListResponse> context)
        {
            var p = new ReactionsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<List<ReactionsListResponse>> ReactionsListAsync(ReactionsListParameter parameter, PagingContext<ReactionsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/reactions.list
        /// </summary>
        public async ValueTask<List<ReactionsListResponse>> ReactionsListAsync(ReactionsListParameter parameter, PagingContext<ReactionsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
