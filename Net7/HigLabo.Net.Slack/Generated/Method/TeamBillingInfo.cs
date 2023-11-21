using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    /// <summary>
    /// https://api.slack.com/methods/team.billing.info
    /// </summary>
    public partial class TeamBillingInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.billing.info";
        string IRestApiParameter.HttpMethod { get; } = "GET";
    }
    public partial class TeamBillingInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/team.billing.info
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/team.billing.info
        /// </summary>
        public async ValueTask<TeamBillingInfoResponse> TeamBillingInfoAsync()
        {
            var p = new TeamBillingInfoParameter();
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.billing.info
        /// </summary>
        public async ValueTask<TeamBillingInfoResponse> TeamBillingInfoAsync(CancellationToken cancellationToken)
        {
            var p = new TeamBillingInfoParameter();
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.billing.info
        /// </summary>
        public async ValueTask<TeamBillingInfoResponse> TeamBillingInfoAsync(TeamBillingInfoParameter parameter)
        {
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/team.billing.info
        /// </summary>
        public async ValueTask<TeamBillingInfoResponse> TeamBillingInfoAsync(TeamBillingInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamBillingInfoParameter, TeamBillingInfoResponse>(parameter, cancellationToken);
        }
    }
}
