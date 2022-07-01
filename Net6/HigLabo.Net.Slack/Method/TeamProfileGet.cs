using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class TeamProfileGetParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.profile.get";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Visibility { get; set; }
    }
    public partial class TeamProfileGetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/team.profile.get
        /// </summary>
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync()
        {
            var p = new TeamProfileGetParameter();
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.profile.get
        /// </summary>
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new TeamProfileGetParameter();
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.profile.get
        /// </summary>
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(TeamProfileGetParameter parameter)
        {
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.profile.get
        /// </summary>
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(TeamProfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(parameter, cancellationToken);
        }
    }
}
