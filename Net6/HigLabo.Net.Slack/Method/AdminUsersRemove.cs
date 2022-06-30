
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersRemoveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.remove";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Id { get; set; }
        public string User_Id { get; set; }
    }
    public partial class AdminUsersRemoveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.remove
        /// </summary>
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersRemoveParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.remove
        /// </summary>
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersRemoveParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.remove
        /// </summary>
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(AdminUsersRemoveParameter parameter)
        {
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.remove
        /// </summary>
        public async Task<AdminUsersRemoveResponse> AdminUsersRemoveAsync(AdminUsersRemoveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersRemoveParameter, AdminUsersRemoveResponse>(parameter, cancellationToken);
        }
    }
}
