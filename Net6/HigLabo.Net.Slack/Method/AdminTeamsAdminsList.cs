
namespace HigLabo.Net.Slack
{
    public partial class AdminTeamsAdminsListParameter : IRestApiParameter, ICursor
    {
        string IRestApiParameter.ApiPath { get; } = "admin.teams.admins.list";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Team_Id { get; set; }
        public string Cursor { get; set; }
        public int? Limit { get; set; }
    }
    public partial class AdminTeamsAdminsListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsAdminsListResponse> AdminTeamsAdminsListAsync(string team_Id)
        {
            var p = new AdminTeamsAdminsListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsAdminsListParameter, AdminTeamsAdminsListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsAdminsListResponse> AdminTeamsAdminsListAsync(string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsAdminsListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsAdminsListParameter, AdminTeamsAdminsListResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsAdminsListResponse> AdminTeamsAdminsListAsync(AdminTeamsAdminsListParameter parameter)
        {
            return await this.SendAsync<AdminTeamsAdminsListParameter, AdminTeamsAdminsListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsAdminsListResponse> AdminTeamsAdminsListAsync(AdminTeamsAdminsListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsAdminsListParameter, AdminTeamsAdminsListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminTeamsAdminsListResponse>> AdminTeamsAdminsListAsync(string team_Id, PagingContext<AdminTeamsAdminsListResponse> context)
        {
            var p = new AdminTeamsAdminsListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsAdminsListResponse>> AdminTeamsAdminsListAsync(string team_Id, PagingContext<AdminTeamsAdminsListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsAdminsListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminTeamsAdminsListResponse>> AdminTeamsAdminsListAsync(AdminTeamsAdminsListParameter parameter, PagingContext<AdminTeamsAdminsListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsAdminsListResponse>> AdminTeamsAdminsListAsync(AdminTeamsAdminsListParameter parameter, PagingContext<AdminTeamsAdminsListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
