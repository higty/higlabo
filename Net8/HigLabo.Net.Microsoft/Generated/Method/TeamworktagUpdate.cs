using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? TeamworkTagId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Tags_TeamworkTagId: return $"/teams/{TeamId}/tags/{TeamworkTagId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Tags_TeamworkTagId,
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
        public string? DisplayName { get; set; }
    }
    public partial class TeamworktagUpdateResponse : RestApiResponse
    {
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public Int32? MemberCount { get; set; }
        public TeamworkTag? TagType { get; set; }
        public string? TeamId { get; set; }
        public TeamworkTagMember[]? Members { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagUpdateResponse> TeamworktagUpdateAsync()
        {
            var p = new TeamworktagUpdateParameter();
            return await this.SendAsync<TeamworktagUpdateParameter, TeamworktagUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagUpdateResponse> TeamworktagUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagUpdateParameter();
            return await this.SendAsync<TeamworktagUpdateParameter, TeamworktagUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagUpdateResponse> TeamworktagUpdateAsync(TeamworktagUpdateParameter parameter)
        {
            return await this.SendAsync<TeamworktagUpdateParameter, TeamworktagUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagUpdateResponse> TeamworktagUpdateAsync(TeamworktagUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagUpdateParameter, TeamworktagUpdateResponse>(parameter, cancellationToken);
        }
    }
}
