
namespace HigLabo.Net.Slack
{
    public partial class AdminInviteRequestsApprovedListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.approved.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsApprovedListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync()
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(p, cancellationToken);
        }
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, PagingContext<AdminInviteRequestsApprovedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
