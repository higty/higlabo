using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAppsRequestsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.requests.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public bool? Certified { get; set; }
        public string? Cursor { get; set; }
        string? IRestApiPagingParameter.NextPageToken
        {
            get
            {
                return this.Cursor;
            }
            set
            {
                this.Cursor = value;
            }
        }
        public string? Enterprise_Id { get; set; }
        public int? Limit { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class AdminAppsRequestsListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.requests.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync()
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter)
        {
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(PagingContext<AdminAppsRequestsListResponse> context)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsRequestsListResponse> context)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, PagingContext<AdminAppsRequestsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.requests.list
        /// </summary>
        public async ValueTask<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, PagingContext<AdminAppsRequestsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
