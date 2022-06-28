
namespace HigLabo.Net.Slack
{
    public class TeamBillingInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "team.billing.info";
        public string HttpMethod { get; private set; } = "GET";
    }
    public partial class TeamBillingInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamBillingInfoResponse> TeamBillingInfoAsync()
        {
            var p = new TeamBillingInfoParameter();
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(p, CancellationToken.None);
        }
        public async Task<TeamBillingInfoResponse> TeamBillingInfoAsync(CancellationToken cancellationToken)
        {
            var p = new TeamBillingInfoParameter();
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(p, cancellationToken);
        }
        public async Task<TeamBillingInfoResponse> TeamBillingInfoAsync(TeamBillingInfoParameter parameter)
        {
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamBillingInfoResponse> TeamBillingInfoAsync(TeamBillingInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(parameter, cancellationToken);
        }
    }
}
