
namespace HigLabo.Net.Slack
{
    public partial class TeamInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Domain { get; set; }
        public string Team { get; set; }
    }
    public partial class TeamInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamInfoResponse> TeamInfoAsync()
        {
            var p = new TeamInfoParameter();
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(p, CancellationToken.None);
        }
        public async Task<TeamInfoResponse> TeamInfoAsync(CancellationToken cancellationToken)
        {
            var p = new TeamInfoParameter();
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(p, cancellationToken);
        }
        public async Task<TeamInfoResponse> TeamInfoAsync(TeamInfoParameter parameter)
        {
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamInfoResponse> TeamInfoAsync(TeamInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamInfoParameter, TeamInfoResponse>(parameter, cancellationToken);
        }
    }
}
