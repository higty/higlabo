
namespace HigLabo.Net.Slack
{
    public class AdminAppsApproveParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.apps.approve";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public string Request_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsApproveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync()
        {
            var p = new AdminAppsApproveParameter();
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsApproveParameter();
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(AdminAppsApproveParameter parameter)
        {
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(AdminAppsApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(parameter, cancellationToken);
        }
    }
}
