
namespace HigLabo.Net.Slack
{
    public class AppsManifestUpdateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "apps.manifest.update";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
        public string Manifest { get; set; } = "";
    }
    public partial class AppsManifestUpdateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsManifestUpdateResponse> AppsManifestUpdateAsync(string app_Id, string manifest)
        {
            var p = new AppsManifestUpdateParameter();
            p.App_Id = app_Id;
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(p, CancellationToken.None);
        }
        public async Task<AppsManifestUpdateResponse> AppsManifestUpdateAsync(string app_Id, string manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestUpdateParameter();
            p.App_Id = app_Id;
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(p, cancellationToken);
        }
        public async Task<AppsManifestUpdateResponse> AppsManifestUpdateAsync(AppsManifestUpdateParameter parameter)
        {
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsManifestUpdateResponse> AppsManifestUpdateAsync(AppsManifestUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(parameter, cancellationToken);
        }
    }
}
