
namespace HigLabo.Net.Slack
{
    public class AppsManifestCreateParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "apps.manifest.create";
        public string HttpMethod { get; private set; } = "POST";
        public string Manifest { get; set; } = "";
    }
    public partial class AppsManifestCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(string manifest)
        {
            var p = new AppsManifestCreateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(p, CancellationToken.None);
        }
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(string manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestCreateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(p, cancellationToken);
        }
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(AppsManifestCreateParameter parameter)
        {
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(AppsManifestCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(parameter, cancellationToken);
        }
    }
}
