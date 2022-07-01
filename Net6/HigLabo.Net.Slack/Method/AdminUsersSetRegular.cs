using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSetRegularParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.setRegular";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Id { get; set; }
        public string User_Id { get; set; }
    }
    public partial class AdminUsersSetRegularResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setRegular
        /// </summary>
        public async Task<AdminUsersSetRegularResponse> AdminUsersSetRegularAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersSetRegularParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetRegularParameter, AdminUsersSetRegularResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setRegular
        /// </summary>
        public async Task<AdminUsersSetRegularResponse> AdminUsersSetRegularAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetRegularParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetRegularParameter, AdminUsersSetRegularResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setRegular
        /// </summary>
        public async Task<AdminUsersSetRegularResponse> AdminUsersSetRegularAsync(AdminUsersSetRegularParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetRegularParameter, AdminUsersSetRegularResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setRegular
        /// </summary>
        public async Task<AdminUsersSetRegularResponse> AdminUsersSetRegularAsync(AdminUsersSetRegularParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetRegularParameter, AdminUsersSetRegularResponse>(parameter, cancellationToken);
        }
    }
}
