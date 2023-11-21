using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.activities.list
    /// </summary>
    public partial class AppsActivitiesListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.activities.list";
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
    public partial class AppsActivitiesListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.activities.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<AppsActivitiesListResponse> AppsActivitiesListAsync(string? app_Id)
        {
            var p = new AppsActivitiesListParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsActivitiesListParameter, AppsActivitiesListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<AppsActivitiesListResponse> AppsActivitiesListAsync(string? app_Id, CancellationToken cancellationToken)
        {
            var p = new AppsActivitiesListParameter();
            p.App_Id = app_Id;
            return await this.SendAsync<AppsActivitiesListParameter, AppsActivitiesListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<AppsActivitiesListResponse> AppsActivitiesListAsync(AppsActivitiesListParameter parameter)
        {
            return await this.SendAsync<AppsActivitiesListParameter, AppsActivitiesListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<AppsActivitiesListResponse> AppsActivitiesListAsync(AppsActivitiesListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsActivitiesListParameter, AppsActivitiesListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async Task<List<AppsActivitiesListResponse>> AppsActivitiesListAsync(string? app_Id, PagingContext<AppsActivitiesListResponse> context)
        {
            var p = new AppsActivitiesListParameter();
            p.App_Id = app_Id;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async Task<List<AppsActivitiesListResponse>> AppsActivitiesListAsync(string? app_Id, PagingContext<AppsActivitiesListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AppsActivitiesListParameter();
            p.App_Id = app_Id;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<List<AppsActivitiesListResponse>> AppsActivitiesListAsync(AppsActivitiesListParameter parameter, PagingContext<AppsActivitiesListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.activities.list
        /// </summary>
        public async ValueTask<List<AppsActivitiesListResponse>> AppsActivitiesListAsync(AppsActivitiesListParameter parameter, PagingContext<AppsActivitiesListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
