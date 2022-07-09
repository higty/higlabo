using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminUsersSessionSetSettingsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.setSettings";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? User_Ids { get; set; }
        public bool? Desktop_App_Browser_Quit { get; set; }
        public int? Duration { get; set; }
    }
    public partial class AdminUsersSessionSetSettingsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.setSettings
        /// </summary>
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(string? user_Ids)
        {
            var p = new AdminUsersSessionSetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.setSettings
        /// </summary>
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(string? user_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionSetSettingsParameter();
            p.User_Ids = user_Ids;
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.setSettings
        /// </summary>
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(AdminUsersSessionSetSettingsParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.setSettings
        /// </summary>
        public async Task<AdminUsersSessionSetSettingsResponse> AdminUsersSessionSetSettingsAsync(AdminUsersSessionSetSettingsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionSetSettingsParameter, AdminUsersSessionSetSettingsResponse>(parameter, cancellationToken);
        }
    }
}
