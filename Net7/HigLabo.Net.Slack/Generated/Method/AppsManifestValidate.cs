using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.validate
    /// </summary>
    public partial class AppsManifestValidateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.manifest.validate";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Manifest { get; set; }
        public string? App_Id { get; set; }
    }
    public partial class AppsManifestValidateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.validate
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.validate
        /// </summary>
        public async ValueTask<AppsManifestValidateResponse> AppsManifestValidateAsync(string? manifest)
        {
            var p = new AppsManifestValidateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.validate
        /// </summary>
        public async ValueTask<AppsManifestValidateResponse> AppsManifestValidateAsync(string? manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestValidateParameter();
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.validate
        /// </summary>
        public async ValueTask<AppsManifestValidateResponse> AppsManifestValidateAsync(AppsManifestValidateParameter parameter)
        {
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.validate
        /// </summary>
        public async ValueTask<AppsManifestValidateResponse> AppsManifestValidateAsync(AppsManifestValidateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestValidateParameter, AppsManifestValidateResponse>(parameter, cancellationToken);
        }
    }
}
