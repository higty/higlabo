using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class TeamworktagDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagDeleteResponse> TeamworktagDeleteAsync()
        {
            var p = new TeamworktagDeleteParameter();
            return await this.SendAsync<TeamworktagDeleteParameter, TeamworktagDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagDeleteResponse> TeamworktagDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagDeleteParameter();
            return await this.SendAsync<TeamworktagDeleteParameter, TeamworktagDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagDeleteResponse> TeamworktagDeleteAsync(TeamworktagDeleteParameter parameter)
        {
            return await this.SendAsync<TeamworktagDeleteParameter, TeamworktagDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagDeleteResponse> TeamworktagDeleteAsync(TeamworktagDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagDeleteParameter, TeamworktagDeleteResponse>(parameter, cancellationToken);
        }
    }
}
