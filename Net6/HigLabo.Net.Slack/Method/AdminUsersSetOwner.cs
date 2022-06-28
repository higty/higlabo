
namespace HigLabo.Net.Slack
{
    public class AdminUsersSetOwnerParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.setOwner";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Id { get; set; } = "";
        public string User_Id { get; set; } = "";
    }
    public partial class AdminUsersSetOwnerResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersSetOwnerParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetOwnerParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(AdminUsersSetOwnerParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(AdminUsersSetOwnerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(parameter, cancellationToken);
        }
    }
}
