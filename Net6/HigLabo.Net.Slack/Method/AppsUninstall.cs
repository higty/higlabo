using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AppsUninstallParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.uninstall";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Client_Id { get; set; }
        public string Client_Secret { get; set; }
    }
    public partial class AppsUninstallResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.uninstall
        /// </summary>
        public async Task<AppsUninstallResponse> AppsUninstallAsync(string client_Id, string client_Secret)
        {
            var p = new AppsUninstallParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.uninstall
        /// </summary>
        public async Task<AppsUninstallResponse> AppsUninstallAsync(string client_Id, string client_Secret, CancellationToken cancellationToken)
        {
            var p = new AppsUninstallParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.uninstall
        /// </summary>
        public async Task<AppsUninstallResponse> AppsUninstallAsync(AppsUninstallParameter parameter)
        {
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.uninstall
        /// </summary>
        public async Task<AppsUninstallResponse> AppsUninstallAsync(AppsUninstallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(parameter, cancellationToken);
        }
    }
}
