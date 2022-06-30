
namespace HigLabo.Net.Slack
{
    public partial class DndTeamInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "dnd.teamInfo";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string Users { get; set; }
        public string Team_Id { get; set; }
    }
    public partial class DndTeamInfoResponse : RestApiResponse
    {
    }
    public partial class SlackClient
    {
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(string users)
        {
            var p = new DndTeamInfoParameter();
            p.Users = users;
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(p, CancellationToken.None);
        }
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(string users, CancellationToken cancellationToken)
        {
            var p = new DndTeamInfoParameter();
            p.Users = users;
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(p, cancellationToken);
        }
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(DndTeamInfoParameter parameter)
        {
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(parameter, CancellationToken.None);
        }
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(DndTeamInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(parameter, cancellationToken);
        }
    }
}
