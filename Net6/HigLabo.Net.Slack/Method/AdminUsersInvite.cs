
namespace HigLabo.Net.Slack
{
    public class AdminUsersInviteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.invite";
        public string HttpMethod { get; private set; } = "POST";
        public string Channel_Ids { get; set; } = "";
        public string Email { get; set; } = "";
        public string Team_Id { get; set; } = "";
        public string Custom_Message { get; set; } = "";
        public bool? Email_Password_Policy_Enabled { get; set; }
        public string Guest_Expiration_Ts { get; set; } = "";
        public bool? Is_Restricted { get; set; }
        public bool? Is_Ultra_Restricted { get; set; }
        public string Real_Name { get; set; } = "";
        public bool? Resend { get; set; }
    }
    public partial class AdminUsersInviteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersInviteResponse> AdminUsersInviteAsync(string channel_Ids, string email, string team_Id)
        {
            var p = new AdminUsersInviteParameter();
            p.Channel_Ids = channel_Ids;
            p.Email = email;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersInviteParameter, AdminUsersInviteResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersInviteResponse> AdminUsersInviteAsync(string channel_Ids, string email, string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersInviteParameter();
            p.Channel_Ids = channel_Ids;
            p.Email = email;
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminUsersInviteParameter, AdminUsersInviteResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersInviteResponse> AdminUsersInviteAsync(AdminUsersInviteParameter parameter)
        {
            return await this.SendAsync<AdminUsersInviteParameter, AdminUsersInviteResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersInviteResponse> AdminUsersInviteAsync(AdminUsersInviteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersInviteParameter, AdminUsersInviteResponse>(parameter, cancellationToken);
        }
    }
}
