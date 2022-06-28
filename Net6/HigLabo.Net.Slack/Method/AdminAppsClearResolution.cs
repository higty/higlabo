
namespace HigLabo.Net.Slack
{
    public class AdminAppsClearResolutionParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.apps.clearResolution";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsClearResolutionResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(string app_Id)
        {
            var p = new AdminAppsClearResolutionParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(string app_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsClearResolutionParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(AdminAppsClearResolutionParameter parameter)
        {
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(AdminAppsClearResolutionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(parameter, cancellationToken);
        }
    }
}
