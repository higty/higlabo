
namespace HigLabo.Net.Slack
{
    public class AppsManifestExportParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "apps.manifest.export";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
    }
    public partial class AppsManifestExportResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsManifestExportResponse> AppsManifestExportAsync(string app_Id)
        {
            var p = new AppsManifestExportParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsManifestExportParameter, AppsManifestExportResponse>(p, CancellationToken.None);
        }
        public async Task<AppsManifestExportResponse> AppsManifestExportAsync(string app_Id, CancellationToken cancellationToken)
        {
            var p = new AppsManifestExportParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsManifestExportParameter, AppsManifestExportResponse>(p, cancellationToken);
        }
        public async Task<AppsManifestExportResponse> AppsManifestExportAsync(AppsManifestExportParameter parameter)
        {
            return await this.SendAsync<AppsManifestExportParameter, AppsManifestExportResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsManifestExportResponse> AppsManifestExportAsync(AppsManifestExportParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestExportParameter, AppsManifestExportResponse>(parameter, cancellationToken);
        }
    }
}
