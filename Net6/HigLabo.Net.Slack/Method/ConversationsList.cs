
namespace HigLabo.Net.Slack
{
    public partial class ConversationsListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Cursor { get; set; }
        public bool? Exclude_Archived { get; set; }
        public double? Limit { get; set; }
        public string Team_Id { get; set; }
        public string Types { get; set; }
    }
    public partial class ConversationsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsListResponse> ConversationsListAsync()
        {
            var p = new ConversationsListParameter();
            return await this.SendAsync<ConversationsListParameter, ConversationsListResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsListResponse> ConversationsListAsync(CancellationToken cancellationToken)
        {
            var p = new ConversationsListParameter();
            return await this.SendAsync<ConversationsListParameter, ConversationsListResponse>(p, cancellationToken);
        }
        public async Task<ConversationsListResponse> ConversationsListAsync(ConversationsListParameter parameter)
        {
            return await this.SendAsync<ConversationsListParameter, ConversationsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsListResponse> ConversationsListAsync(ConversationsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsListParameter, ConversationsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<ConversationsListResponse>> ConversationsListAsync(PagingContext<ConversationsListResponse> context)
        {
            var p = new ConversationsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ConversationsListResponse>> ConversationsListAsync(CancellationToken cancellationToken, PagingContext<ConversationsListResponse> context)
        {
            var p = new ConversationsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ConversationsListResponse>> ConversationsListAsync(ConversationsListParameter parameter, PagingContext<ConversationsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ConversationsListResponse>> ConversationsListAsync(ConversationsListParameter parameter, PagingContext<ConversationsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
