using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworktagmemberGetParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
    public partial class TeamworktagmemberGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? TenantId { get; set; }
        public string? UserId { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberGetResponse> TeamworktagmemberGetAsync()
        {
            var p = new TeamworktagmemberGetParameter();
            return await this.SendAsync<TeamworktagmemberGetParameter, TeamworktagmemberGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberGetResponse> TeamworktagmemberGetAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworktagmemberGetParameter();
            return await this.SendAsync<TeamworktagmemberGetParameter, TeamworktagmemberGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberGetResponse> TeamworktagmemberGetAsync(TeamworktagmemberGetParameter parameter)
        {
            return await this.SendAsync<TeamworktagmemberGetParameter, TeamworktagmemberGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamworktagmember-get?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworktagmemberGetResponse> TeamworktagmemberGetAsync(TeamworktagmemberGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworktagmemberGetParameter, TeamworktagmemberGetResponse>(parameter, cancellationToken);
        }
    }
}
