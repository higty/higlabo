
namespace HigLabo.Net.Slack
{
    public partial class AppsManifestCreateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.manifest.create";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Manifest { get; set; }
    }
    public partial class AppsManifestCreateResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.create
        /// </summary>
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(string manifest)
        {
            var p = new AppsManifestCreateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.create
        /// </summary>
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(string manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestCreateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.create
        /// </summary>
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(AppsManifestCreateParameter parameter)
        {
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.create
        /// </summary>
        public async Task<AppsManifestCreateResponse> AppsManifestCreateAsync(AppsManifestCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestCreateParameter, AppsManifestCreateResponse>(parameter, cancellationToken);
        }
    }
}
