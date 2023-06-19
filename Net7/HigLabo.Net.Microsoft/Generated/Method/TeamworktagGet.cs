using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class TeamworktagGetResponse : RestApiResponse
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
    /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagGetResponse> TeamworktagGetAsync()
        {
            var p = new TeamworktagGetParameter();
            return await this.SendAsync<TeamworktagGetParameter, TeamworktagGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagGetResponse> TeamworktagGetAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagGetParameter();
            return await this.SendAsync<TeamworktagGetParameter, TeamworktagGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagGetResponse> TeamworktagGetAsync(TeamworktagGetParameter parameter)
        {
            return await this.SendAsync<TeamworktagGetParameter, TeamworktagGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktag-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamworktagGetResponse> TeamworktagGetAsync(TeamworktagGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagGetParameter, TeamworktagGetResponse>(parameter, cancellationToken);
        }
    }
}
