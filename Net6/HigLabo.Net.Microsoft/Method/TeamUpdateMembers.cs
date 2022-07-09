using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamUpdateMembersParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string[]? Roles { get; set; }
    }
    public partial class TeamUpdateMembersResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string[]? Roles { get; set; }
        public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUpdateMembersResponse> TeamUpdateMembersAsync()
        {
            var p = new TeamUpdateMembersParameter();
            return await this.SendAsync<TeamUpdateMembersParameter, TeamUpdateMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUpdateMembersResponse> TeamUpdateMembersAsync(CancellationToken cancellationToken)
        {
            var p = new TeamUpdateMembersParameter();
            return await this.SendAsync<TeamUpdateMembersParameter, TeamUpdateMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUpdateMembersResponse> TeamUpdateMembersAsync(TeamUpdateMembersParameter parameter)
        {
            return await this.SendAsync<TeamUpdateMembersParameter, TeamUpdateMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-update-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamUpdateMembersResponse> TeamUpdateMembersAsync(TeamUpdateMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamUpdateMembersParameter, TeamUpdateMembersResponse>(parameter, cancellationToken);
        }
    }
}
