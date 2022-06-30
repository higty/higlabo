
namespace HigLabo.Net.Slack
{
    public partial class AdminInviteRequestsListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync()
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(p, cancellationToken);
        }
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(PagingContext<AdminInviteRequestsListResponse> context)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsListResponse> context)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, PagingContext<AdminInviteRequestsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, PagingContext<AdminInviteRequestsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
