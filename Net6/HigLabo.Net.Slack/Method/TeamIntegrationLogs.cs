
namespace HigLabo.Net.Slack
{
    public partial class TeamIntegrationLogsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.integrationLogs";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string App_Id { get; set; }
        public string Change_Type { get; set; }
        public string Count { get; set; }
        public string Page { get; set; }
        public string Service_Id { get; set; }
        public string Team_Id { get; set; }
        public string User { get; set; }
    }
    public partial class TeamIntegrationLogsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamIntegrationLogsResponse> TeamIntegrationLogsAsync()
        {
            var p = new TeamIntegrationLogsParameter();
            return await this.SendAsync<TeamIntegrationLogsParameter, TeamIntegrationLogsResponse>(p, CancellationToken.None);
        }
        public async Task<TeamIntegrationLogsResponse> TeamIntegrationLogsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamIntegrationLogsParameter();
            return await this.SendAsync<TeamIntegrationLogsParameter, TeamIntegrationLogsResponse>(p, cancellationToken);
        }
        public async Task<TeamIntegrationLogsResponse> TeamIntegrationLogsAsync(TeamIntegrationLogsParameter parameter)
        {
            return await this.SendAsync<TeamIntegrationLogsParameter, TeamIntegrationLogsResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamIntegrationLogsResponse> TeamIntegrationLogsAsync(TeamIntegrationLogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamIntegrationLogsParameter, TeamIntegrationLogsResponse>(parameter, cancellationToken);
        }
    }
}
