
namespace HigLabo.Net.Slack
{
    public class ConversationsMembersParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "conversations.members";
        public string HttpMethod { get; private set; } = "GET";
        public string Channel { get; set; } = "";
        public string Cursor { get; set; } = "";
        public double? Limit { get; set; }
    }
    public partial class ConversationsMembersResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(string channel)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(p, CancellationToken.None);
        }
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(p, cancellationToken);
        }
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(ConversationsMembersParameter parameter)
        {
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(parameter, CancellationToken.None);
        }
        public async Task<ConversationsMembersResponse> ConversationsMembersAsync(ConversationsMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsMembersParameter, ConversationsMembersResponse>(parameter, cancellationToken);
        }
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(string channel, PagingContext<ConversationsMembersResponse> context)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(string channel, PagingContext<ConversationsMembersResponse> context, CancellationToken cancellationToken)
        {
            var p = new ConversationsMembersParameter();
            p.Channel = channel;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(ConversationsMembersParameter parameter, PagingContext<ConversationsMembersResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<ConversationsMembersResponse>> ConversationsMembersAsync(ConversationsMembersParameter parameter, PagingContext<ConversationsMembersResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
