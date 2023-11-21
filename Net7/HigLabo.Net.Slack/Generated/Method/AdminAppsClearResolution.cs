using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.clearResolution
    /// </summary>
    public partial class AdminAppsClearResolutionParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.clearResolution";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Id { get; set; }
        public string? Enterprise_Id { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminAppsClearResolutionResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.clearResolution
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.clearResolution
        /// </summary>
        public async ValueTask<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(string? app_Id)
        {
            var p = new AdminAppsClearResolutionParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.clearResolution
        /// </summary>
        public async ValueTask<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(string? app_Id, CancellationToken cancellationToken)
        {
            var p = new AdminAppsClearResolutionParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.clearResolution
        /// </summary>
        public async ValueTask<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(AdminAppsClearResolutionParameter parameter)
        {
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.clearResolution
        /// </summary>
        public async ValueTask<AdminAppsClearResolutionResponse> AdminAppsClearResolutionAsync(AdminAppsClearResolutionParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsClearResolutionParameter, AdminAppsClearResolutionResponse>(parameter, cancellationToken);
        }
    }
}
