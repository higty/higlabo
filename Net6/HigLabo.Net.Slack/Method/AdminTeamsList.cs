using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.list";
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
    }
    public partial class AdminTeamsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync()
        {
            var p = new AdminTeamsListParameter();
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(CancellationToken cancellationToken)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(AdminTeamsListParameter parameter)
        {
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<AdminTeamsListResponse> AdminTeamsListAsync(AdminTeamsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsListParameter, AdminTeamsListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(PagingContext<AdminTeamsListResponse> context)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(CancellationToken cancellationToken, PagingContext<AdminTeamsListResponse> context)
        {
            var p = new AdminTeamsListParameter();
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(AdminTeamsListParameter parameter, PagingContext<AdminTeamsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.list
        /// </summary>
        public async Task<List<AdminTeamsListResponse>> AdminTeamsListAsync(AdminTeamsListParameter parameter, PagingContext<AdminTeamsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
