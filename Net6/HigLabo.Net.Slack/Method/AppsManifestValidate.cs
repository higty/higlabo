
namespace HigLabo.Net.Slack
{
    public partial class AppsManifestValidateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.manifest.validate";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Manifest { get; set; }
        public string App_Id { get; set; }
    }
    public partial class AppsManifestValidateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsManifestValidateResponse> AppsManifestValidateAsync(string manifest)
        {
            var p = new AppsManifestValidateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(p, CancellationToken.None);
        }
        public async Task<AppsManifestValidateResponse> AppsManifestValidateAsync(string manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestValidateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(p, cancellationToken);
        }
        public async Task<AppsManifestValidateResponse> AppsManifestValidateAsync(AppsManifestValidateParameter parameter)
        {
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsManifestValidateResponse> AppsManifestValidateAsync(AppsManifestValidateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(parameter, cancellationToken);
        }
    }
}
