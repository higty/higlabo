
namespace HigLabo.Net.Slack
{
    public partial class TeamBillableInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "team.billableInfo";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Team_Id { get; set; }
        public string User { get; set; }
    }
    public partial class TeamBillableInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<TeamBillableInfoResponse> TeamBillableInfoAsync()
        {
            var p = new TeamBillableInfoParameter();
            return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(p, CancellationToken.None);
        }
        public async Task<TeamBillableInfoResponse> TeamBillableInfoAsync(CancellationToken cancellationToken)
        {
            var p = new TeamBillableInfoParameter();
            return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(p, cancellationToken);
        }
        public async Task<TeamBillableInfoResponse> TeamBillableInfoAsync(TeamBillableInfoParameter parameter)
        {
            return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<TeamBillableInfoResponse> TeamBillableInfoAsync(TeamBillableInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamBillableInfoParameter, TeamBillableInfoResponse>(parameter, cancellationToken);
        }
    }
}
