using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class TeamAccessLogsParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.accessLogs";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Before { get; set; }
        public string Count { get; set; }
        public string Page { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class TeamAccessLogsResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/team.accessLogs
        /// </summary>
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync()
        {
            var p = new TeamAccessLogsParameter();
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.accessLogs
        /// </summary>
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamAccessLogsParameter();
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.accessLogs
        /// </summary>
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter)
        {
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.accessLogs
        /// </summary>
        public async Task<TeamAccessLogsResponse> TeamAccessLogsAsync(TeamAccessLogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamAccessLogsParameter, TeamAccessLogsResponse>(parameter, cancellationToken);
        }
    }
}
