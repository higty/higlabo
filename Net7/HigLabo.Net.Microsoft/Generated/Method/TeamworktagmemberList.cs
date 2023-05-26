using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagmemberListParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Teams_TeamId_Tags_TeamworkTagId_Members: return $"/teams/{TeamId}/tags/{TeamworkTagId}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DisplayName,
            Id,
            TenantId,
            UserId,
        }
        public enum ApiPath
        {
            Teams_TeamId_Tags_TeamworkTagId_Members,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class TeamworktagmemberListResponse : RestApiResponse
    {
        public TeamworkTagMember[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberListResponse> TeamworktagmemberListAsync()
        {
            var p = new TeamworktagmemberListParameter();
            return await this.SendAsync<TeamworktagmemberListParameter, TeamworktagmemberListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberListResponse> TeamworktagmemberListAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagmemberListParameter();
            return await this.SendAsync<TeamworktagmemberListParameter, TeamworktagmemberListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberListResponse> TeamworktagmemberListAsync(TeamworktagmemberListParameter parameter)
        {
            return await this.SendAsync<TeamworktagmemberListParameter, TeamworktagmemberListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberListResponse> TeamworktagmemberListAsync(TeamworktagmemberListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagmemberListParameter, TeamworktagmemberListResponse>(parameter, cancellationToken);
        }
    }
}
