using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionClearSettingsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.clearSettings";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? User_Ids { get; set; }
    }
    public partial class AdminUsersSessionClearSettingsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.clearSettings
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.clearSettings
        /// </summary>
        public async ValueTask<AdminUsersSessionClearSettingsResponse> AdminUsersSessionClearSettingsAsync(string? user_Ids)
        {
            var p = new AdminUsersSessionClearSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionClearSettingsParameter, AdminUsersSessionClearSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.clearSettings
        /// </summary>
        public async ValueTask<AdminUsersSessionClearSettingsResponse> AdminUsersSessionClearSettingsAsync(string? user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionClearSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionClearSettingsParameter, AdminUsersSessionClearSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.clearSettings
        /// </summary>
        public async ValueTask<AdminUsersSessionClearSettingsResponse> AdminUsersSessionClearSettingsAsync(AdminUsersSessionClearSettingsParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionClearSettingsParameter, AdminUsersSessionClearSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.clearSettings
        /// </summary>
        public async ValueTask<AdminUsersSessionClearSettingsResponse> AdminUsersSessionClearSettingsAsync(AdminUsersSessionClearSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionClearSettingsParameter, AdminUsersSessionClearSettingsResponse>(parameter, cancellationToken);
        }
    }
}
