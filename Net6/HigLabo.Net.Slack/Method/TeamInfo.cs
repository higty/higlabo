
namespace HigLabo.Net.Slack
{
    public class TeamInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "team.info";
        public string HttpMethod { get; private set; } = "GET";
        public string Domain { get; set; } = "";
        public string Team { get; set; } = "";
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
