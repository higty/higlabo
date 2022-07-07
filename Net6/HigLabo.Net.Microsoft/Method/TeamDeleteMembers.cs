using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamDeleteMembersParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_Members_MembershipId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Members_MembershipId: return $"/teams/{TeamId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string MembershipId { get; set; }
    }
    public partial class TeamDeleteMembersResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync()
        {
            var p = new TeamDeleteMembersParameter();
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new TeamDeleteMembersParameter();
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(TeamDeleteMembersParameter parameter)
        {
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(TeamDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
