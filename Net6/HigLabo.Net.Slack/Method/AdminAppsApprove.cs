
namespace HigLabo.Net.Slack
{
    public partial class AdminAppsApproveParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.approve";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string App_Id { get; set; }
        public string Enterprise_Id { get; set; }
        public string Request_Id { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminAppsApproveResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approve
        /// </summary>
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync()
        {
            var p = new AdminAppsApproveParameter();
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approve
        /// </summary>
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsApproveParameter();
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approve
        /// </summary>
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(AdminAppsApproveParameter parameter)
        {
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approve
        /// </summary>
        public async Task<AdminAppsApproveResponse> AdminAppsApproveAsync(AdminAppsApproveParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsApproveParameter, AdminAppsApproveResponse>(parameter, cancellationToken);
        }
    }
}
