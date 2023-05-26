using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsInviteSharedParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.inviteShared";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Channel { get; set; }
        public string? Emails { get; set; }
        public bool? External_Limited { get; set; }
        public string? User_Ids { get; set; }
    }
    public partial class ConversationsInviteSharedResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.inviteShared
        /// </summary>
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(string? channel)
        {
            var p = new ConversationsInviteSharedParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.inviteShared
        /// </summary>
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(string? channel, CancellationToken cancellationToken)
        {
            var p = new ConversationsInviteSharedParameter();
            p.Channel = channel;
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.inviteShared
        /// </summary>
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(ConversationsInviteSharedParameter parameter)
        {
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.inviteShared
        /// </summary>
        public async Task<ConversationsInviteSharedResponse> ConversationsInviteSharedAsync(ConversationsInviteSharedParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsInviteSharedParameter, ConversationsInviteSharedResponse>(parameter, cancellationToken);
        }
    }
}
