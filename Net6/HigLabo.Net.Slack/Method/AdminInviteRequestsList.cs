using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminInviteRequestsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.inviteRequests.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string Cursor { get; set; }
        string IRestApiPagingParameter.NextPageToken
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
        public string Team_Id { get; set; }
    }
    public partial class AdminInviteRequestsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync()
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter)
        {
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<AdminInviteRequestsListResponse> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminInviteRequestsListParameter, AdminInviteRequestsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(PagingContext<AdminInviteRequestsListResponse> context)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(CancellationToken cancellationToken, PagingContext<AdminInviteRequestsListResponse> context)
        {
            var p = new AdminInviteRequestsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, PagingContext<AdminInviteRequestsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.inviteRequests.list
        /// </summary>
        public async Task<List<AdminInviteRequestsListResponse>> AdminInviteRequestsListAsync(AdminInviteRequestsListParameter parameter, PagingContext<AdminInviteRequestsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
