using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSetOwnerParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.setOwner";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Team_Id { get; set; }
        public string User_Id { get; set; }
    }
    public partial class AdminUsersSetOwnerResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setOwner
        /// </summary>
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(string team_Id, string user_Id)
        {
            var p = new AdminUsersSetOwnerParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setOwner
        /// </summary>
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(string team_Id, string user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetOwnerParameter();
            p.Team_Id = team_Id;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setOwner
        /// </summary>
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(AdminUsersSetOwnerParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setOwner
        /// </summary>
        public async Task<AdminUsersSetOwnerResponse> AdminUsersSetOwnerAsync(AdminUsersSetOwnerParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetOwnerParameter, AdminUsersSetOwnerResponse>(parameter, cancellationToken);
        }
    }
}
