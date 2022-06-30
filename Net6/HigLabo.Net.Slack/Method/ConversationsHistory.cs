
namespace HigLabo.Net.Slack
{
    public partial class ConversationsHistoryParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.history";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string Cursor { get; set; }
        public bool? Include_All_Metadata { get; set; }
        public bool? Inclusive { get; set; }
        public string Latest { get; set; }
        public double? Limit { get; set; }
        public string Oldest { get; set; }
    }
    public partial class ConversationsHistoryResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsHistoryResponse> ConversationsHistoryAsync(string channel)
        {
            var p = new ConversationsHistoryParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsHistoryParameter, ConversationsHistoryResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsHistoryResponse> ConversationsHistoryAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsHistoryParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsHistoryParameter, ConversationsHistoryResponse>(p, cancellationToken);
        }
        public async Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistoryParameter parameter)
        {
            return await this.SendAsync<ConversationsHistoryParameter, ConversationsHistoryResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsHistoryResponse> ConversationsHistoryAsync(ConversationsHistoryParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsHistoryParameter, ConversationsHistoryResponse>(parameter, cancellationToken);
        }
        public async Task<List<ConversationsHistoryResponse>> ConversationsHistoryAsync(string channel, PagingContext<ConversationsHistoryResponse> context)
        {
            var p = new ConversationsHistoryParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ConversationsHistoryResponse>> ConversationsHistoryAsync(string channel, PagingContext<ConversationsHistoryResponse> context, CancellationToken cancellationToken)
        {
            var p = new ConversationsHistoryParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ConversationsHistoryResponse>> ConversationsHistoryAsync(ConversationsHistoryParameter parameter, PagingContext<ConversationsHistoryResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ConversationsHistoryResponse>> ConversationsHistoryAsync(ConversationsHistoryParameter parameter, PagingContext<ConversationsHistoryResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
