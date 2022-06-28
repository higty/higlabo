
namespace HigLabo.Net.Slack
{
    public class AdminTeamsOwnersListParameter : IRestApiParameter, ICursor
    {
        public string ApiPath { get; private set; } = "admin.teams.owners.list";
        public string HttpMethod { get; private set; } = "GET";
        public string Team_Id { get; set; } = "";
        public string Cursor { get; set; } = "";
        public int? Limit { get; set; }
    }
    public partial class AdminTeamsOwnersListResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(string team_Id)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(p, CancellationToken.None);
        }
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(string team_Id, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(p, cancellationToken);
        }
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter)
        {
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(parameter, CancellationToken.None);
        }
        public async Task<AdminTeamsOwnersListResponse> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AdminTeamsOwnersListParameter, AdminTeamsOwnersListResponse>(parameter, cancellationToken);
        }
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(string team_Id, PagingContext<AdminTeamsOwnersListResponse> context)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(string team_Id, PagingContext<AdminTeamsOwnersListResponse> context, CancellationToken cancellationToken)
        {
            var p = new AdminTeamsOwnersListParameter();
            p.Team_Id = team_Id;
            return await this.SendBatchAsync(p, context, cancellationToken);
        }
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, PagingContext<AdminTeamsOwnersListResponse> context)
        {
            return await this.SendBatchAsync(parameter, context, CancellationToken.None);
        }
        public async Task<List<AdminTeamsOwnersListResponse>> AdminTeamsOwnersListAsync(AdminTeamsOwnersListParameter parameter, PagingContext<AdminTeamsOwnersListResponse> context, CancellationToken cancellationToken)
        {
            return await this.SendBatchAsync(parameter, context, cancellationToken);
        }
    }
}
