using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.list
    /// </summary>
    public partial class AdminFunctionsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.functions.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? App_Ids { get; set; }
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
        public string? Team_Id { get; set; }
    }
    public partial class AdminFunctionsListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.functions.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<AdminFunctionsListResponse> AdminFunctionsListAsync(string? app_Ids)
        {
            var p = new AdminFunctionsListParameter();
            p.App_Ids = app_Ids;
            return await this.SendAsync<AdminFunctionsListParameter, AdminFunctionsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<AdminFunctionsListResponse> AdminFunctionsListAsync(string? app_Ids, CancellationToken cancellationToken)
        {
            var p = new AdminFunctionsListParameter();
            p.App_Ids = app_Ids;
            return await this.SendAsync<AdminFunctionsListParameter, AdminFunctionsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<AdminFunctionsListResponse> AdminFunctionsListAsync(AdminFunctionsListParameter parameter)
        {
            return await this.SendAsync<AdminFunctionsListParameter, AdminFunctionsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<AdminFunctionsListResponse> AdminFunctionsListAsync(AdminFunctionsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminFunctionsListParameter, AdminFunctionsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async Task<List<AdminFunctionsListResponse>> AdminFunctionsListAsync(string? app_Ids, PagingContext<AdminFunctionsListResponse> context)
        {
            var p = new AdminFunctionsListParameter();
            p.App_Ids = app_Ids;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async Task<List<AdminFunctionsListResponse>> AdminFunctionsListAsync(string? app_Ids, PagingContext<AdminFunctionsListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminFunctionsListParameter();
            p.App_Ids = app_Ids;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<List<AdminFunctionsListResponse>> AdminFunctionsListAsync(AdminFunctionsListParameter parameter, PagingContext<AdminFunctionsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.functions.list
        /// </summary>
        public async ValueTask<List<AdminFunctionsListResponse>> AdminFunctionsListAsync(AdminFunctionsListParameter parameter, PagingContext<AdminFunctionsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
