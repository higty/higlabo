
namespace HigLabo.Net.Slack
{
    public class AdminAppsRestrictParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "admin.apps.restrict";
        public string HttpMethod { get; private set; } = "POST";
        public string App_Id { get; set; } = "";
        public string Enterprise_Id { get; set; } = "";
        public string Request_Id { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class AdminAppsRestrictResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync()
        {
            var p = new AdminAppsRestrictParameter();
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRestrictParameter();
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(AdminAppsRestrictParameter parameter)
        {
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(AdminAppsRestrictParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(parameter, cancellationToken);
        }
    }
}
