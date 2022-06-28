
namespace HigLabo.Net.Slack
{
    public class AdminUsersSetAdminParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.setAdmin";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Id { get; set; } = "";
        public string User_Id { get; set; } = "";
    }
    public partial class AdminUsersSetAdminResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersSetAdminParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetAdminParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(AdminUsersSetAdminParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(AdminUsersSetAdminParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(parameter, cancellationToken);
        }
    }
}
