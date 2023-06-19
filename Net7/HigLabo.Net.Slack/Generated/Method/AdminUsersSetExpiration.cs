using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSetExpirationParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.setExpiration";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public int? Expiration_Ts { get; set; }
        public string? User_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminUsersSetExpirationResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.setExpiration
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setExpiration
        /// </summary>
        public async ValueTask<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(int? expiration_Ts, string? user_Id)
        {
            var p = new AdminUsersSetExpirationParameter();
            p.Expiration_Ts = expiration_Ts;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setExpiration
        /// </summary>
        public async ValueTask<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(int? expiration_Ts, string? user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSetExpirationParameter();
            p.Expiration_Ts = expiration_Ts;
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setExpiration
        /// </summary>
        public async ValueTask<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(AdminUsersSetExpirationParameter parameter)
        {
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.setExpiration
        /// </summary>
        public async ValueTask<AdminUsersSetExpirationResponse> AdminUsersSetExpirationAsync(AdminUsersSetExpirationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSetExpirationParameter, AdminUsersSetExpirationResponse>(parameter, cancellationToken);
        }
    }
}
