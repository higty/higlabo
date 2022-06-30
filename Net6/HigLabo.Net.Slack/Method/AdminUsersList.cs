﻿
namespace HigLabo.Net.Slack
{
    public partial class AdminUsersListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminUsersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminUsersListResponse> AdminUsersListAsync()
        {
            var p = new AdminUsersListParameter();
            return await this.SendAsync<AdminUsersListParameter, AdminUsersListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminUsersListResponse> AdminUsersListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminUsersListParameter();
            return await this.SendAsync<AdminUsersListParameter, AdminUsersListResponse>(p, cancellationToken);
        }
        public async Task<AdminUsersListResponse> AdminUsersListAsync(AdminUsersListParameter parameter)
        {
            return await this.SendAsync<AdminUsersListParameter, AdminUsersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminUsersListResponse> AdminUsersListAsync(AdminUsersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersListParameter, AdminUsersListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminUsersListResponse>> AdminUsersListAsync(PagingContext<AdminUsersListResponse> context)
        {
            var p = new AdminUsersListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminUsersListResponse>> AdminUsersListAsync(CancellationToken cancellationToken, PagingContext<AdminUsersListResponse> context)
        {
            var p = new AdminUsersListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminUsersListResponse>> AdminUsersListAsync(AdminUsersListParameter parameter, PagingContext<AdminUsersListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminUsersListResponse>> AdminUsersListAsync(AdminUsersListParameter parameter, PagingContext<AdminUsersListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}