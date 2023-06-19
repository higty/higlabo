using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsKickParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.kick";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
        public string? User { get; set; }
    }
    public partial class ConversationsKickResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.kick
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.kick
        /// </summary>
        public async ValueTask<ConversationsKickResponse> ConversationsKickAsync(string? channel, string? user)
        {
            var p = new ConversationsKickParameter();
            p.Channel = channel;
            p.User = user;
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.kick
        /// </summary>
        public async ValueTask<ConversationsKickResponse> ConversationsKickAsync(string? channel, string? user, CancellationToken cancellationToken)
        {
            var p = new ConversationsKickParameter();
            p.Channel = channel;
            p.User = user;
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.kick
        /// </summary>
        public async ValueTask<ConversationsKickResponse> ConversationsKickAsync(ConversationsKickParameter parameter)
        {
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.kick
        /// </summary>
        public async ValueTask<ConversationsKickResponse> ConversationsKickAsync(ConversationsKickParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsKickParameter, ConversationsKickResponse>(parameter, cancellationToken);
        }
    }
}
