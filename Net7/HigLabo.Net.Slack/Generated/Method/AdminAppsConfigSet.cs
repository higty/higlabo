using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.config.set
    /// </summary>
    public partial class AdminAppsConfigSetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.config.set";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Id { get; set; }
        public object? Domain_Restrictions { get; set; }
        public string? Workflow_Auth_Strategy { get; set; }
    }
    public partial class AdminAppsConfigSetResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.config.set
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.set
        /// </summary>
        public async ValueTask<AdminAppsConfigSetResponse> AdminAppsConfigSetAsync(string? app_Id)
        {
            var p = new AdminAppsConfigSetParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsConfigSetParameter, AdminAppsConfigSetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.set
        /// </summary>
        public async ValueTask<AdminAppsConfigSetResponse> AdminAppsConfigSetAsync(string? app_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsConfigSetParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsConfigSetParameter, AdminAppsConfigSetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.set
        /// </summary>
        public async ValueTask<AdminAppsConfigSetResponse> AdminAppsConfigSetAsync(AdminAppsConfigSetParameter parameter)
        {
            return await this.SendAsync<AdminAppsConfigSetParameter, AdminAppsConfigSetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.set
        /// </summary>
        public async ValueTask<AdminAppsConfigSetResponse> AdminAppsConfigSetAsync(AdminAppsConfigSetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsConfigSetParameter, AdminAppsConfigSetResponse>(parameter, cancellationToken);
        }
    }
}
