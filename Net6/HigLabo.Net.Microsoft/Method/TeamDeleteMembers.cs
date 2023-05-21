using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class TeamDeleteMembersParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? MembershipId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Members_MembershipId: return $"/teams/{TeamId}/members/{MembershipId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Members_MembershipId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TeamDeleteMembersResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync()
        {
            var p = new TeamDeleteMembersParameter();
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(CancellationToken cancellationToken)
        {
            var p = new TeamDeleteMembersParameter();
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(TeamDeleteMembersParameter parameter)
        {
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-delete-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteMembersResponse> TeamDeleteMembersAsync(TeamDeleteMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamDeleteMembersParameter, TeamDeleteMembersResponse>(parameter, cancellationToken);
        }
    }
}
