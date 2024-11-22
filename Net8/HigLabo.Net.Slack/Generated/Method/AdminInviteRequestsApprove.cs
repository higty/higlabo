using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack;

public partial class AdminInviteRequestsApproveParameter : IRestApiParameter
{
    string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.approve";
    string IRestApiParameter.HttpMethod { get; } = "POST";
    public string? Invite_Request_Id { get; set; }
    public string? Team_Id { get; set; }
}
public partial class AdminInviteRequestsApproveResponse : RestApiResponse
{
}
/// <summary>
/// https://api.slack.com/methods/admin.inviteRequests.approve
/// </summary>
public partial class SlackClient
{
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.approve
    /// </summary>
    public async ValueTask<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(string? invite_Request_Id)
    {
        var p = new AdminInviteRequestsApproveParameter();
        p.Invite_Request_Id = invite_Request_Id;
        return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(p, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.approve
    /// </summary>
    public async ValueTask<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(string? invite_Request_Id, CancellationToken cancellationToken)
    {
        var p = new AdminInviteRequestsApproveParameter();
        p.Invite_Request_Id = invite_Request_Id;
        return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(p, cancellationToken);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.approve
    /// </summary>
    public async ValueTask<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(AdminInviteRequestsApproveParameter parameter)
    {
        return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(parameter, CancellationToken.None);
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.inviteRequests.approve
    /// </summary>
    public async ValueTask<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(AdminInviteRequestsApproveParameter parameter, CancellationToken cancellationToken)
    {
        return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(parameter, cancellationToken);
    }
}
