using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminAppsRestrictedListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.restricted.list";
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
    public partial class AdminAppsRestrictedListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.restricted.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync()
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter)
        {
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<AdminAppsRestrictedListResponse> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRestrictedListParameter, AdminAppsRestrictedListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(PagingContext<AdminAppsRestrictedListResponse> context)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsRestrictedListResponse> context)
        {
            var p = new AdminAppsRestrictedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, PagingContext<AdminAppsRestrictedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.restricted.list
        /// </summary>
        public async Task<List<AdminAppsRestrictedListResponse>> AdminAppsRestrictedListAsync(AdminAppsRestrictedListParameter parameter, PagingContext<AdminAppsRestrictedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
