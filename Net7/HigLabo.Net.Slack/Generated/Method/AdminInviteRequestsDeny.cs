using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.deny
    /// </summary>
    public partial class AdminInviteRequestsDenyParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.deny";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Invite_Request_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsDenyResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.deny
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.deny
        /// </summary>
        public async ValueTask<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(string? invite_Request_Id)
        {
            var p = new AdminInviteRequestsDenyParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.deny
        /// </summary>
        public async ValueTask<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(string? invite_Request_Id, CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsDenyParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.deny
        /// </summary>
        public async ValueTask<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(AdminInviteRequestsDenyParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.deny
        /// </summary>
        public async ValueTask<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(AdminInviteRequestsDenyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(parameter, cancellationToken);
        }
    }
}
