
namespace HigLabo.Net.Slack
{
    public class AdminInviteRequestsApproveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.inviteRequests.approve";
        public string HttpMethod { get; private set; } = "POST";
        public string Invite_Request_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminInviteRequestsApproveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(string invite_Request_Id)
        {
            var p = new AdminInviteRequestsApproveParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(p, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(string invite_Request_Id, CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsApproveParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(p, cancellationToken);
        }
        public async Task<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(AdminInviteRequestsApproveParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsApproveResponse> AdminInviteRequestsApproveAsync(AdminInviteRequestsApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsApproveParameter, AdminInviteRequestsApproveResponse>(parameter, cancellationToken);
        }
    }
}
