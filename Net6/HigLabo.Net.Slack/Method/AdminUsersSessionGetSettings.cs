
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionGetSettingsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.getSettings";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string User_Ids { get; set; }
    }
    public partial class AdminUsersSessionGetSettingsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.getSettings
        /// </summary>
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(string user_Ids)
        {
            var p = new AdminUsersSessionGetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.getSettings
        /// </summary>
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(string user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionGetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.getSettings
        /// </summary>
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(AdminUsersSessionGetSettingsParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.getSettings
        /// </summary>
        public async Task<AdminUsersSessionGetSettingsResponse> AdminUsersSessionGetSettingsAsync(AdminUsersSessionGetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionGetSettingsParameter, AdminUsersSessionGetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
