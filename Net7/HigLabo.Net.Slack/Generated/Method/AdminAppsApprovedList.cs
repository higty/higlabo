using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.approved.list
    /// </summary>
    public partial class AdminAppsApprovedListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.approved.list";
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
    public partial class AdminAppsApprovedListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.approved.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync()
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter)
        {
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<AdminAppsApprovedListResponse> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsApprovedListParameter, AdminAppsApprovedListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(PagingContext<AdminAppsApprovedListResponse> context)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async Task<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsApprovedListResponse> context)
        {
            var p = new AdminAppsApprovedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, PagingContext<AdminAppsApprovedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.approved.list
        /// </summary>
        public async ValueTask<List<AdminAppsApprovedListResponse>> AdminAppsApprovedListAsync(AdminAppsApprovedListParameter parameter, PagingContext<AdminAppsApprovedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
