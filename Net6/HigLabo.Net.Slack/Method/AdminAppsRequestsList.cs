﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminAppsRequestsListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.apps.requests.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Cursor { get; set; }
        public string Enterprise_Id { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminAppsRequestsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync()
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(p, cancellationToken);
        }
        public async Task<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter)
        {
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminAppsRequestsListResponse> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminAppsRequestsListParameter, AdminAppsRequestsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(PagingContext<AdminAppsRequestsListResponse> context)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(CancellationToken cancellationToken, PagingContext<AdminAppsRequestsListResponse> context)
        {
            var p = new AdminAppsRequestsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, PagingContext<AdminAppsRequestsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminAppsRequestsListResponse>> AdminAppsRequestsListAsync(AdminAppsRequestsListParameter parameter, PagingContext<AdminAppsRequestsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}