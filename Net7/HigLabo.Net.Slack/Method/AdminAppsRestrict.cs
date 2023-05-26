using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAppsRestrictParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.restrict";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Id { get; set; }
        public string? Enterprise_Id { get; set; }
        public string? Request_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminAppsRestrictResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restrict
        /// </summary>
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync()
        {
            var p = new AdminAppsRestrictParameter();
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restrict
        /// </summary>
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRestrictParameter();
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restrict
        /// </summary>
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(AdminAppsRestrictParameter parameter)
        {
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restrict
        /// </summary>
        public async Task<AdminAppsRestrictResponse> AdminAppsRestrictAsync(AdminAppsRestrictParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRestrictParameter, AdminAppsRestrictResponse>(parameter, cancellationToken);
        }
    }
}
