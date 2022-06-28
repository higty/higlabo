
namespace HigLabo.Net.Slack
{
    public class TeamProfileGetParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "team.profile.get";
        public string HttpMethod { get; private set; } = "GET";
        public string Visibility { get; set; } = "";
    }
    public partial class TeamProfileGetResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync()
        {
            var p = new TeamProfileGetParameter();
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(p, CancellationToken.None);
        }
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(CancellationToken cancellationToken)
        {
            var p = new TeamProfileGetParameter();
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(p, cancellationToken);
        }
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(TeamProfileGetParameter parameter)
        {
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamProfileGetResponse> TeamProfileGetAsync(TeamProfileGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamProfileGetParameter, TeamProfileGetResponse>(parameter, cancellationToken);
        }
    }
}
