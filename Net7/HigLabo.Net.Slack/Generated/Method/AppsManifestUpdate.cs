using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.update
    /// </summary>
    public partial class AppsManifestUpdateParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.manifest.update";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Id { get; set; }
        public string? Manifest { get; set; }
    }
    public partial class AppsManifestUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.manifest.update
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.update
        /// </summary>
        public async ValueTask<AppsManifestUpdateResponse> AppsManifestUpdateAsync(string? app_Id, string? manifest)
        {
            var p = new AppsManifestUpdateParameter();
            p.App_Id = app_Id;
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.update
        /// </summary>
        public async ValueTask<AppsManifestUpdateResponse> AppsManifestUpdateAsync(string? app_Id, string? manifest, CancellationToken cancellationToken)
        {
            var p = new AppsManifestUpdateParameter();
            p.App_Id = app_Id;
            p.Manifest = manifest;
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.update
        /// </summary>
        public async ValueTask<AppsManifestUpdateResponse> AppsManifestUpdateAsync(AppsManifestUpdateParameter parameter)
        {
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.manifest.update
        /// </summary>
        public async ValueTask<AppsManifestUpdateResponse> AppsManifestUpdateAsync(AppsManifestUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestUpdateParameter, AppsManifestUpdateResponse>(parameter, cancellationToken);
        }
    }
}
