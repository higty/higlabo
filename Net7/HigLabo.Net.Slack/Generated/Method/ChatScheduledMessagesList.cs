using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/chat.scheduledMessages.list
    /// </summary>
    public partial class ChatScheduledMessagesListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "chat.scheduledMessages.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
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
        public string? Latest { get; set; }
        public int? Limit { get; set; }
        public string? Oldest { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class ChatScheduledMessagesListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/chat.scheduledMessages.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync()
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(CancellationToken cancellationToken)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter)
        {
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<ChatScheduledMessagesListResponse> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ChatScheduledMessagesListParameter, ChatScheduledMessagesListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(PagingContext<ChatScheduledMessagesListResponse> context)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async Task<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(CancellationToken cancellationToken, PagingContext<ChatScheduledMessagesListResponse> context)
        {
            var p = new ChatScheduledMessagesListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, PagingContext<ChatScheduledMessagesListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/chat.scheduledMessages.list
        /// </summary>
        public async ValueTask<List<ChatScheduledMessagesListResponse>> ChatScheduledMessagesListAsync(ChatScheduledMessagesListParameter parameter, PagingContext<ChatScheduledMessagesListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
