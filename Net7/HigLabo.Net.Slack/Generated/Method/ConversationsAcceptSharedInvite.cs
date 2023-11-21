using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/conversations.acceptSharedInvite
    /// </summary>
    public partial class ConversationsAcceptSharedInviteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.acceptSharedInvite";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Channel_Name { get; set; }
        public string? Channel_Id { get; set; }
        public bool? Free_Trial_Accepted { get; set; }
        public string? Invite_Id { get; set; }
        public bool? Is_Private { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class ConversationsAcceptSharedInviteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/conversations.acceptSharedInvite
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.acceptSharedInvite
        /// </summary>
        public async ValueTask<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(string? channel_Name)
        {
            var p = new ConversationsAcceptSharedInviteParameter();
            p.Channel_Name = channel_Name;
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.acceptSharedInvite
        /// </summary>
        public async ValueTask<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(string? channel_Name, CancellationToken cancellationToken)
        {
            var p = new ConversationsAcceptSharedInviteParameter();
            p.Channel_Name = channel_Name;
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.acceptSharedInvite
        /// </summary>
        public async ValueTask<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(ConversationsAcceptSharedInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.acceptSharedInvite
        /// </summary>
        public async ValueTask<ConversationsAcceptSharedInviteResponse> ConversationsAcceptSharedInviteAsync(ConversationsAcceptSharedInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsAcceptSharedInviteParameter, ConversationsAcceptSharedInviteResponse>(parameter, cancellationToken);
        }
    }
}
