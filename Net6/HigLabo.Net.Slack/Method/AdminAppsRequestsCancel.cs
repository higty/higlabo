
namespace HigLabo.Net.Slack
{
    public class AdminAppsRequestsCancelParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.apps.requests.cancel";
        public string HttpMethod { get; private set; } = "POST";
        public string Request_Id { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsRequestsCancelResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(string request_Id)
        {
            var p = new AdminAppsRequestsCancelParameter();
            p.Request_Id = request_Id;
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(string request_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsRequestsCancelParameter();
            p.Request_Id = request_Id;
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(AdminAppsRequestsCancelParameter parameter)
        {
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(AdminAppsRequestsCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(parameter, cancellationToken);
        }
    }
}
