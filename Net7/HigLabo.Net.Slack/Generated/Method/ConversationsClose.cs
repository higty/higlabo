using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.close
    /// </summary>
    public partial class ConversationsCloseParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.close";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
    }
    public partial class ConversationsCloseResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.close
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.close
        /// </summary>
        public async ValueTask<ConversationsCloseResponse> ConversationsCloseAsync(string? channel)
        {
            var p = new ConversationsCloseParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.close
        /// </summary>
        public async ValueTask<ConversationsCloseResponse> ConversationsCloseAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsCloseParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.close
        /// </summary>
        public async ValueTask<ConversationsCloseResponse> ConversationsCloseAsync(ConversationsCloseParameter parameter)
        {
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.close
        /// </summary>
        public async ValueTask<ConversationsCloseResponse> ConversationsCloseAsync(ConversationsCloseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsCloseParameter, ConversationsCloseResponse>(parameter, cancellationToken);
        }
    }
}
