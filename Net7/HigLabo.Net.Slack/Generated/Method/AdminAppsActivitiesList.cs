using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.activities.list
    /// </summary>
    public partial class AdminAppsActivitiesListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.activities.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? App_Id { get; set; }
        public string? Component_Id { get; set; }
        public string? Component_Type { get; set; }
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
        public int? Limit { get; set; }
        public string? Log_Event_Type { get; set; }
        public int? Max_Date_Created { get; set; }
        public int? Min_Date_Created { get; set; }
        public string? Min_Log_Level { get; set; }
        public string? Sort_Direction { get; set; }
        public string? Source { get; set; }
        public string? Team_Id { get; set; }
        public string? Trace_Id { get; set; }
    }
    public partial class AdminAppsActivitiesListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.apps.activities.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<AdminAppsActivitiesListResponse> AdminAppsActivitiesListAsync()
        {
            var p = new AdminAppsActivitiesListParameter();
            return await this.SendAsync<AdminAppsActivitiesListParameter, AdminAppsActivitiesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<AdminAppsActivitiesListResponse> AdminAppsActivitiesListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsActivitiesListParameter();
            return await this.SendAsync<AdminAppsActivitiesListParameter, AdminAppsActivitiesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<AdminAppsActivitiesListResponse> AdminAppsActivitiesListAsync(AdminAppsActivitiesListParameter parameter)
        {
            return await this.SendAsync<AdminAppsActivitiesListParameter, AdminAppsActivitiesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<AdminAppsActivitiesListResponse> AdminAppsActivitiesListAsync(AdminAppsActivitiesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsActivitiesListParameter, AdminAppsActivitiesListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async Task<List<AdminAppsActivitiesListResponse>> AdminAppsActivitiesListAsync(PagingContext<AdminAppsActivitiesListResponse> context)
        {
            var p = new AdminAppsActivitiesListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async Task<List<AdminAppsActivitiesListResponse>> AdminAppsActivitiesListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsActivitiesListResponse> context)
        {
            var p = new AdminAppsActivitiesListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<List<AdminAppsActivitiesListResponse>> AdminAppsActivitiesListAsync(AdminAppsActivitiesListParameter parameter, PagingContext<AdminAppsActivitiesListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.apps.activities.list
        /// </summary>
        public async ValueTask<List<AdminAppsActivitiesListResponse>> AdminAppsActivitiesListAsync(AdminAppsActivitiesListParameter parameter, PagingContext<AdminAppsActivitiesListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
