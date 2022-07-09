using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class ConversationsApproveSharedInviteParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "conversations.approveSharedInvite";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Invite_Id { get; set; }
        public string? Target_Team { get; set; }
    }
    public partial class ConversationsApproveSharedInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/conversations.approveSharedInvite
        /// </summary>
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(string? invite_Id)
        {
            var p = new ConversationsApproveSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.approveSharedInvite
        /// </summary>
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(string? invite_Id, CancellationToken cancellationToken)
        {
            var p = new ConversationsApproveSharedInviteParameter();
            p.Invite_Id = invite_Id;
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.approveSharedInvite
        /// </summary>
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(ConversationsApproveSharedInviteParameter parameter)
        {
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/conversations.approveSharedInvite
        /// </summary>
        public async Task<ConversationsApproveSharedInviteResponse> ConversationsApproveSharedInviteAsync(ConversationsApproveSharedInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConversationsApproveSharedInviteParameter, ConversationsApproveSharedInviteResponse>(parameter, cancellationToken);
        }
    }
}
