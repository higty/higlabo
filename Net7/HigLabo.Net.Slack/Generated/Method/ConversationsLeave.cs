using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.leave
    /// </summary>
    public partial class ConversationsLeaveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.leave";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel { get; set; }
    }
    public partial class ConversationsLeaveResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.leave
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.leave
        /// </summary>
        public async ValueTask<ConversationsLeaveResponse> ConversationsLeaveAsync(string? channel)
        {
            var p = new ConversationsLeaveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.leave
        /// </summary>
        public async ValueTask<ConversationsLeaveResponse> ConversationsLeaveAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsLeaveParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.leave
        /// </summary>
        public async ValueTask<ConversationsLeaveResponse> ConversationsLeaveAsync(ConversationsLeaveParameter parameter)
        {
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.leave
        /// </summary>
        public async ValueTask<ConversationsLeaveResponse> ConversationsLeaveAsync(ConversationsLeaveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsLeaveParameter, ConversationsLeaveResponse>(parameter, cancellationToken);
        }
    }
}
