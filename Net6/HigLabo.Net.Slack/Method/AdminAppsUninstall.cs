using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAppsUninstallParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.uninstall";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string App_Id { get; set; }
        public string Enterprise_Id { get; set; }
        public string Team_Ids { get; set; }
    }
    public partial class AdminAppsUninstallResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.uninstall
        /// </summary>
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(string app_Id)
        {
            var p = new AdminAppsUninstallParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.uninstall
        /// </summary>
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(string app_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsUninstallParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.uninstall
        /// </summary>
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(AdminAppsUninstallParameter parameter)
        {
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.uninstall
        /// </summary>
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(AdminAppsUninstallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(parameter, cancellationToken);
        }
    }
}
