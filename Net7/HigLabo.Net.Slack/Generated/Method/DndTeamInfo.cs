using HigLabo.Net.OAuth;

namespace HigLabo.Net.Slack
{
    public partial class DndTeamInfoParameter : IRestApiParameter
    {
        string IRestApiParameter.ApiPath { get; } = "dnd.teamInfo";
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public string? Users { get; set; }
        public string? Team_Id { get; set; }
    }
    public partial class DndTeamInfoResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://api.slack.com/methods/dnd.teamInfo
    /// </summary>
    public partial class SlackClient
    {
        /// <summary>
        /// https://api.slack.com/methods/dnd.teamInfo
        /// </summary>
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(string? users)
        {
            var p = new DndTeamInfoParameter();
            p.Users = users;
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.teamInfo
        /// </summary>
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(string? users, CancellationToken cancellationToken)
        {
            var p = new DndTeamInfoParameter();
            p.Users = users;
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.teamInfo
        /// </summary>
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(DndTeamInfoParameter parameter)
        {
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://api.slack.com/methods/dnd.teamInfo
        /// </summary>
        public async Task<DndTeamInfoResponse> DndTeamInfoAsync(DndTeamInfoParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DndTeamInfoParameter, DndTeamInfoResponse>(parameter, cancellationToken);
        }
    }
}
