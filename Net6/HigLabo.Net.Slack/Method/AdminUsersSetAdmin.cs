
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSetAdminParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.setAdmin";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Id { get; set; }
        public string User_Id { get; set; }
    }
    public partial class AdminUsersSetAdminResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setAdmin
        /// </summary>
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersSetAdminParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setAdmin
        /// </summary>
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetAdminParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setAdmin
        /// </summary>
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(AdminUsersSetAdminParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setAdmin
        /// </summary>
        public async Task<AdminUsersSetAdminResponse> AdminUsersSetAdminAsync(AdminUsersSetAdminParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetAdminParameter, AdminUsersSetAdminResponse>(parameter, cancellationToken);
        }
    }
}
