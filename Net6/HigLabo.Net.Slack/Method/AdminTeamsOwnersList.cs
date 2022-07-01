using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsOwnersListParameter : IRestApiParameter, IRestApiPagingParameter
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.owners.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Team_Id { get; set; }
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
    public partial class AdminTeamsOwnersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(string team_Id)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter)
        {
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(string team_Id, PagingContext<AdminTeamsOwnersListResponse> context)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(string team_Id, PagingContext<AdminTeamsOwnersListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, PagingContext<AdminTeamsOwnersListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/admin.teams.owners.list
        /// </summary>
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, PagingContext<AdminTeamsOwnersListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
