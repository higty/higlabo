using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_Tags: return $"/teams/{TeamId}/tags";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
            MemberCount,
            TagType,
            TeamId,
            Members,
        }
        public enum ApiPath
        {
            Teams_TeamId_Tags,
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
    public partial class TeamworktagListResponse : RestApiResponse
    {
        public TeamworkTag[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagListResponse> TeamworktagListAsync()
        {
            var p = new TeamworktagListParameter();
            return await this.SendAsync<TeamworktagListParameter, TeamworktagListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagListResponse> TeamworktagListAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagListParameter();
            return await this.SendAsync<TeamworktagListParameter, TeamworktagListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagListResponse> TeamworktagListAsync(TeamworktagListParameter parameter)
        {
            return await this.SendAsync<TeamworktagListParameter, TeamworktagListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-list?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagListResponse> TeamworktagListAsync(TeamworktagListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagListParameter, TeamworktagListResponse>(parameter, cancellationToken);
        }
    }
}
