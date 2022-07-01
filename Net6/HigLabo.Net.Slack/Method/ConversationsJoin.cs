using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsJoinParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.join";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Channel { get; set; }
    }
    public partial class ConversationsJoinResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.join
        /// </summary>
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(string channel)
        {
            var p = new ConversationsJoinParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.join
        /// </summary>
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(string channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsJoinParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.join
        /// </summary>
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(ConversationsJoinParameter parameter)
        {
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.join
        /// </summary>
        public async Task<ConversationsJoinResponse> ConversationsJoinAsync(ConversationsJoinParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsJoinParameter, ConversationsJoinResponse>(parameter, cancellationToken);
        }
    }
}
