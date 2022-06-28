
namespace HigLabo.Net.Slack
{
    public class AdminUsersRemoveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.remove";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Id { get; set; } = "";
        public string User_Id { get; set; } = "";
    }
    public partial class AdminUsersRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersRemoveParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersRemoveParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(AdminUsersRemoveParameter parameter)
        {
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(AdminUsersRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(parameter, cancellationToken);
        }
    }
}
