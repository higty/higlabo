
namespace HigLabo.Net.Slack
{
    public partial class ChatScheduledMessagesListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "chat.scheduledMessages.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
        public string Cursor { get; set; }
        public string Latest { get; set; }
        public int? Limit { get; set; }
        public string Oldest { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class ChatScheduledMessagesListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync()
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(p, CancellationToken.None);
        }
        public async Task<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(CancellationToken cancellationToken)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(p, cancellationToken);
        }
        public async Task<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter)
        {
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(parameter, CancellationToken.None);
        }
        public async Task<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(parameter, cancellationToken);
        }
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(PagingContext<ChatScheduledMessagesListResponse> context)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(CancellationToken cancellationToken, PagingContext<ChatScheduledMessagesListResponse> context)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, PagingContext<ChatScheduledMessagesListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, PagingContext<ChatScheduledMessagesListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
