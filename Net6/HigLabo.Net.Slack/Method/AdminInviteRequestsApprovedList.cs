
namespace HigLabo.Net.Slack
{
    public partial class AdminInviteRequestsApprovedListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.approved.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        string IRestApiPagingParameter.NextPageToken { get; set; }
        public int? Limit { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsApprovedListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync()
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<AdminInviteRequestsApprovedListResponse> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsApprovedListParameter, AdminInviteRequestsApprovedListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            var p = new AdminInviteRequestsApprovedListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, PagingContext<AdminInviteRequestsApprovedListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.approved.list
        /// </summary>
        public async Task<List<AdminInviteRequestsApprovedListResponse>> AdminInviteRequestsApprovedListAsync(AdminInviteRequestsApprovedListParameter parameter, PagingContext<AdminInviteRequestsApprovedListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
