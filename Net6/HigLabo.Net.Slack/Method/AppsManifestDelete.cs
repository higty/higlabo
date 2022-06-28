
namespace HigLabo.Net.Slack
{
    public class AppsManifestDeleteParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "apps.manifest.delete";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
    }
    public partial class AppsManifestDeleteResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AppsManifestDeleteResponse> AppsManifestDeleteAsync(string app_Id)
        {
            var p = new AppsManifestDeleteParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(p, CancellationToken.None);
        }
        public async Task<AppsManifestDeleteResponse> AppsManifestDeleteAsync(string app_Id, CancellationToken cancellationToken)
        {
            var p = new AppsManifestDeleteParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(p, cancellationToken);
        }
        public async Task<AppsManifestDeleteResponse> AppsManifestDeleteAsync(AppsManifestDeleteParameter parameter)
        {
            return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(parameter, CancellationToken.None);
        }
        public async Task<AppsManifestDeleteResponse> AppsManifestDeleteAsync(AppsManifestDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsManifestDeleteParameter, AppsManifestDeleteResponse>(parameter, cancellationToken);
        }
    }
}
