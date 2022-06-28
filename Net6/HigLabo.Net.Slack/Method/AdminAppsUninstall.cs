
namespace HigLabo.Net.Slack
{
    public class AdminAppsUninstallParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.apps.uninstall";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public string Team_Ids { get; set; } = "";
    }
    public partial class AdminAppsUninstallResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(string app_Id)
        {
            var p = new AdminAppsUninstallParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(string app_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsUninstallParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(AdminAppsUninstallParameter parameter)
        {
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsUninstallResponse> AdminAppsUninstallAsync(AdminAppsUninstallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsUninstallParameter, AdminAppsUninstallResponse>(parameter, cancellationToken);
        }
    }
}
