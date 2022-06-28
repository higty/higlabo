
namespace HigLabo.Net.Slack
{
    public class AdminUsersAssignParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.users.assign";
        public string HttpMethod { get; private set; } = "POST";
        public string Team_Id { get; set; } = "";
        public string User_Id { get; set; } = "";
        public string Channel_Ids { get; set; } = "";
        public bool? Is_Restricted { get; set; }
        public bool? Is_Ultra_Restricted { get; set; }
    }
    public partial class AdminUsersAssignResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersAssignResponse> AdminUsersAssignAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersAssignParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersAssignParameter, AdminUsersAssignResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersAssignResponse> AdminUsersAssignAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersAssignParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersAssignParameter, AdminUsersAssignResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersAssignResponse> AdminUsersAssignAsync(AdminUsersAssignParameter parameter)
        {
            return await this.SendAsync<AdminUsersAssignParameter, AdminUsersAssignResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersAssignResponse> AdminUsersAssignAsync(AdminUsersAssignParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersAssignParameter, AdminUsersAssignResponse>(parameter, cancellationToken);
        }
    }
}
