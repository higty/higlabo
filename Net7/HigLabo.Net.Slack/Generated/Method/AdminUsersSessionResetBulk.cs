using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionResetBulkParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.resetBulk";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? User_Ids { get; set; }
        public bool? Mobile_Only { get; set; }
        public bool? Web_Only { get; set; }
    }
    public partial class AdminUsersSessionResetBulkResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.resetBulk
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.resetBulk
        /// </summary>
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(string? user_Ids)
        {
            var p = new AdminUsersSessionResetBulkParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.resetBulk
        /// </summary>
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(string? user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionResetBulkParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.resetBulk
        /// </summary>
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(AdminUsersSessionResetBulkParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.resetBulk
        /// </summary>
        public async Task<AdminUsersSessionResetBulkResponse> AdminUsersSessionResetBulkAsync(AdminUsersSessionResetBulkParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionResetBulkParameter, AdminUsersSessionResetBulkResponse>(parameter, cancellationToken);
        }
    }
}
