using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagmemberDeleteParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? TeamworkTagId { get; set; }
            public string? TeamworkTagMemberId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Tags_TeamworkTagId_Members_TeamworkTagMemberId: return $"/teams/{TeamId}/tags/{TeamworkTagId}/members/{TeamworkTagMemberId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_Tags_TeamworkTagId_Members_TeamworkTagMemberId,
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
    public partial class TeamworktagmemberDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagmemberDeleteResponse> TeamworktagmemberDeleteAsync()
        {
            var p = new TeamworktagmemberDeleteParameter();
            return await this.SendAsync<TeamworktagmemberDeleteParameter, TeamworktagmemberDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagmemberDeleteResponse> TeamworktagmemberDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagmemberDeleteParameter();
            return await this.SendAsync<TeamworktagmemberDeleteParameter, TeamworktagmemberDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagmemberDeleteResponse> TeamworktagmemberDeleteAsync(TeamworktagmemberDeleteParameter parameter)
        {
            return await this.SendAsync<TeamworktagmemberDeleteParameter, TeamworktagmemberDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagmemberDeleteResponse> TeamworktagmemberDeleteAsync(TeamworktagmemberDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagmemberDeleteParameter, TeamworktagmemberDeleteResponse>(parameter, cancellationToken);
        }
    }
}
