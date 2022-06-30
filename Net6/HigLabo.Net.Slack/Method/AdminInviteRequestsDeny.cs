
namespace HigLabo.Net.Slack
{
    public partial class AdminInviteRequestsDenyParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.deny";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Invite_Request_Id { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsDenyResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(string invite_Request_Id)
        {
            var p = new AdminInviteRequestsDenyParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(p, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(string invite_Request_Id, CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsDenyParameter();
            p.Invite_Request_Id = invite_Request_Id;
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(p, cancellationToken);
        }
        public async Task<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(AdminInviteRequestsDenyParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsDenyResponse> AdminInviteRequestsDenyAsync(AdminInviteRequestsDenyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsDenyParameter, AdminInviteRequestsDenyResponse>(parameter, cancellationToken);
        }
    }
}
