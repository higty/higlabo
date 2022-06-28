
namespace HigLabo.Net.Slack
{
    public class AppsUninstallParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "apps.uninstall";
        public string HttpMethod { get; private set; } = "GET";
        public string Client_Id { get; set; } = "";
        public string Client_Secret { get; set; } = "";
    }
    public partial class AppsUninstallResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsUninstallResponse> AppsUninstallAsync(string client_Id, string client_Secret)
        {
            var p = new AppsUninstallParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(p, CancellationToken.None);
        }
        public async Task<AppsUninstallResponse> AppsUninstallAsync(string client_Id, string client_Secret, CancellationToken cancellationToken)
        {
            var p = new AppsUninstallParameter();
            p.Client_Id = client_Id;
            p.Client_Secret = client_Secret;
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(p, cancellationToken);
        }
        public async Task<AppsUninstallResponse> AppsUninstallAsync(AppsUninstallParameter parameter)
        {
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsUninstallResponse> AppsUninstallAsync(AppsUninstallParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsUninstallParameter, AppsUninstallResponse>(parameter, cancellationToken);
        }
    }
}
