using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/apps.event.authorizations.list
    /// </summary>
    public partial class AppsEventAuthorizationsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "apps.event.authorizations.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Event_Context { get; set; }
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
    }
    public partial class AppsEventAuthorizationsListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/apps.event.authorizations.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(string? event_Context)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(string? event_Context, CancellationToken cancellationToken)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter)
        {
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<AppsEventAuthorizationsListResponse> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AppsEventAuthorizationsListParameter, AppsEventAuthorizationsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(string? event_Context, PagingContext<AppsEventAuthorizationsListResponse> context)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async Task<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(string? event_Context, PagingContext<AppsEventAuthorizationsListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AppsEventAuthorizationsListParameter();
            p.Event_Context = event_Context;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, PagingContext<AppsEventAuthorizationsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/apps.event.authorizations.list
        /// </summary>
        public async ValueTask<List<AppsEventAuthorizationsListResponse>> AppsEventAuthorizationsListAsync(AppsEventAuthorizationsListParameter parameter, PagingContext<AppsEventAuthorizationsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
