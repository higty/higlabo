
namespace HigLabo.Net.Slack
{
    public class TeamAccessLogsParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "team.accessLogs";
        public string HttpMethod { get; private set; } = "GET";
        public string Before { get; set; } = "";
        public string Count { get; set; } = "";
        public string Page { get; set; } = "";
        public string Team_Id { get; set; } = "";
    }
    public partial class TeamAccessLogsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync()
        {
            var p = new TeamAccessLogsParameter();
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, CancellationToken.None);
        }
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamAccessLogsParameter();
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, cancellationToken);
        }
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter)
        {
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, cancellationToken);
        }
    }
}
