
namespace HigLabo.Net.Slack
{
    public class TeamBillableInfoParameter : IRestApiParameter
    {
        public string ApiPath { get; private set; } = "team.billableInfo";
        public string HttpMethod { get; private set; } = "GET";
        public string Team_Id { get; set; } = "";
        public string User { get; set; } = "";
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
