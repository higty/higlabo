using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.config.lookup
    /// </summary>
    public partial class AdminAppsConfigLookupParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.config.lookup";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Ids { get; set; }
    }
    public partial class AdminAppsConfigLookupResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.config.lookup
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.lookup
        /// </summary>
        public async ValueTask<AdminAppsConfigLookupResponse> AdminAppsConfigLookupAsync(string? app_Ids)
        {
            var p = new AdminAppsConfigLookupParameter();
            p.App_Ids = app_Ids;
            return await this.SendAsync<AdminAppsConfigLookupParameter, AdminAppsConfigLookupResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.lookup
        /// </summary>
        public async ValueTask<AdminAppsConfigLookupResponse> AdminAppsConfigLookupAsync(string? app_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminAppsConfigLookupParameter();
            p.App_Ids = app_Ids;
            return await this.SendAsync<AdminAppsConfigLookupParameter, AdminAppsConfigLookupResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.lookup
        /// </summary>
        public async ValueTask<AdminAppsConfigLookupResponse> AdminAppsConfigLookupAsync(AdminAppsConfigLookupParameter parameter)
        {
            return await this.SendAsync<AdminAppsConfigLookupParameter, AdminAppsConfigLookupResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.config.lookup
        /// </summary>
        public async ValueTask<AdminAppsConfigLookupResponse> AdminAppsConfigLookupAsync(AdminAppsConfigLookupParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsConfigLookupParameter, AdminAppsConfigLookupResponse>(parameter, cancellationToken);
        }
    }
}
