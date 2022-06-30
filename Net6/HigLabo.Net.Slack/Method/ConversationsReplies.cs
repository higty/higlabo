
namespace HigLabo.Net.Slack
{
    public partial class ConversationsRepliesParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.replies";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Channel { get; set; }
        public string Ts { get; set; }
        public string Cursor { get; set; }
        public bool? Inclusive { get; set; }
        public string Latest { get; set; }
        public double? Limit { get; set; }
        public string Oldest { get; set; }
    }
    public partial class ConversationsRepliesResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsRepliesResponse> ConversationsRepliesAsync(string channel, string ts)
        {
            var p = new ConversationsRepliesParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsRepliesResponse> ConversationsRepliesAsync(string channel, string ts, CancellationToken cancellationToken)
        {
            var p = new ConversationsRepliesParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(p, cancellationToken);
        }
        public async Task<ConversationsRepliesResponse> ConversationsRepliesAsync(ConversationsRepliesParameter parameter)
        {
            return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsRepliesResponse> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsRepliesParameter, ConversationsRepliesResponse>(parameter, cancellationToken);
        }
        public async Task<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(string channel, PagingContext<ConversationsRepliesResponse> context, string ts)
        {
            var p = new ConversationsRepliesParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(string channel, PagingContext<ConversationsRepliesResponse> context, string ts, CancellationToken cancellationToken)
        {
            var p = new ConversationsRepliesParameter();
            p.Channel = channel;
            p.Ts = ts;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, PagingContext<ConversationsRepliesResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ConversationsRepliesResponse>> ConversationsRepliesAsync(ConversationsRepliesParameter parameter, PagingContext<ConversationsRepliesResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
