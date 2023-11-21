using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.listAssignments
    /// </summary>
    public partial class AdminRolesListAssignmentsParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.roles.listAssignments";
        string IRestApiParameter.HttpMethod { get; } = "GET";
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
        public string? Entity_Ids { get; set; }
        public int? Limit { get; set; }
        public string? Role_Ids { get; set; }
        public SortDirection Sort_Dir { get; set; }
    }
    public partial class AdminRolesListAssignmentsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/admin.roles.listAssignments
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<AdminRolesListAssignmentsResponse> AdminRolesListAssignmentsAsync()
        {
            var p = new AdminRolesListAssignmentsParameter();
            return await this.SendAsync<AdminRolesListAssignmentsParameter, AdminRolesListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<AdminRolesListAssignmentsResponse> AdminRolesListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new AdminRolesListAssignmentsParameter();
            return await this.SendAsync<AdminRolesListAssignmentsParameter, AdminRolesListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<AdminRolesListAssignmentsResponse> AdminRolesListAssignmentsAsync(AdminRolesListAssignmentsParameter parameter)
        {
            return await this.SendAsync<AdminRolesListAssignmentsParameter, AdminRolesListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<AdminRolesListAssignmentsResponse> AdminRolesListAssignmentsAsync(AdminRolesListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminRolesListAssignmentsParameter, AdminRolesListAssignmentsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async Task<List<AdminRolesListAssignmentsResponse>> AdminRolesListAssignmentsAsync(PagingContext<AdminRolesListAssignmentsResponse> context)
        {
            var p = new AdminRolesListAssignmentsParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async Task<List<AdminRolesListAssignmentsResponse>> AdminRolesListAssignmentsAsync(CancellationToken cancellationToken, PagingContext<AdminRolesListAssignmentsResponse> context)
        {
            var p = new AdminRolesListAssignmentsParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<List<AdminRolesListAssignmentsResponse>> AdminRolesListAssignmentsAsync(AdminRolesListAssignmentsParameter parameter, PagingContext<AdminRolesListAssignmentsResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.roles.listAssignments
        /// </summary>
        public async ValueTask<List<AdminRolesListAssignmentsResponse>> AdminRolesListAssignmentsAsync(AdminRolesListAssignmentsParameter parameter, PagingContext<AdminRolesListAssignmentsResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
