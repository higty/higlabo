using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.list
    /// </summary>
    public partial class AdminUsersSessionListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.users.session.list";
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public string? User_Id { get; set; }
    }
    public partial class AdminUsersSessionListResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.users.session.list
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<AdminUsersSessionListResponse> AdminUsersSessionListAsync()
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<AdminUsersSessionListResponse> AdminUsersSessionListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<AdminUsersSessionListResponse> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter)
        {
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<AdminUsersSessionListResponse> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminUsersSessionListParameter, AdminUsersSessionListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(PagingContext<AdminUsersSessionListResponse> context)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async Task<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(CancellationToken cancellationToken, PagingContext<AdminUsersSessionListResponse> context)
        {
            var p = new AdminUsersSessionListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, PagingContext<AdminUsersSessionListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.users.session.list
        /// </summary>
        public async ValueTask<List<AdminUsersSessionListResponse>> AdminUsersSessionListAsync(AdminUsersSessionListParameter parameter, PagingContext<AdminUsersSessionListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
