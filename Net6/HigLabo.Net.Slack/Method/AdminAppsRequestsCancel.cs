
namespace HigLabo.Net.Slack
{
    public partial class AdminAppsRequestsCancelParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.requests.cancel";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Request_Id { get; set; }
        public string Enterprise_Id { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminAppsRequestsCancelResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.cancel
        /// </summary>
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(string request_Id)
        {
            var p = new AdminAppsRequestsCancelParameter();
            p.Request_Id = request_Id;
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.cancel
        /// </summary>
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(string request_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsRequestsCancelParameter();
            p.Request_Id = request_Id;
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.cancel
        /// </summary>
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(AdminAppsRequestsCancelParameter parameter)
        {
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.cancel
        /// </summary>
        public async Task<AdminAppsRequestsCancelResponse> AdminAppsRequestsCancelAsync(AdminAppsRequestsCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRequestsCancelParameter, AdminAppsRequestsCancelResponse>(parameter, cancellationToken);
        }
    }
}
