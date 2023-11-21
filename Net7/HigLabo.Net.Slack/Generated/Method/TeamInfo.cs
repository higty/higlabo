using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/team.info
    /// </summary>
    public partial class TeamInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Domain { get; set; }
        public string? Team { get; set; }
    }
    public partial class TeamInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/team.info
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/team.info
        /// </summary>
        public async ValueTask<TeamInfoResponse> TeamInfoAsync()
        {
            var p = new TeamInfoParameter();
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.info
        /// </summary>
        public async ValueTask<TeamInfoResponse> TeamInfoAsync(CancellationToken cancellationToken)
        {
            var p = new TeamInfoParameter();
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.info
        /// </summary>
        public async ValueTask<TeamInfoResponse> TeamInfoAsync(TeamInfoParameter parameter)
        {
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.info
        /// </summary>
        public async ValueTask<TeamInfoResponse> TeamInfoAsync(TeamInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(parameter, cancellationToken);
        }
    }
}
