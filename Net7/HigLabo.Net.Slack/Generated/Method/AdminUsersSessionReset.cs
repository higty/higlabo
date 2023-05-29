using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionResetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.reset";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? User_Id { get; set; }
        public bool? Mobile_Only { get; set; }
        public bool? Web_Only { get; set; }
    }
    public partial class AdminUsersSessionResetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.reset
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.reset
        /// </summary>
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(string? user_Id)
        {
            var p = new AdminUsersSessionResetParameter();
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.reset
        /// </summary>
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(string? user_Id, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionResetParameter();
            p.User_Id = user_Id;
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.reset
        /// </summary>
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(AdminUsersSessionResetParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.reset
        /// </summary>
        public async Task<AdminUsersSessionResetResponse> AdminUsersSessionResetAsync(AdminUsersSessionResetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionResetParameter, AdminUsersSessionResetResponse>(parameter, cancellationToken);
        }
    }
}
