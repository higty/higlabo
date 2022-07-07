using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamListMembersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_Members,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_Members: return $"/teams/{TeamId}/members";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
        public string TeamId { get; set; }
    }
    public partial class TeamListMembersResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/conversationmember?view=graph-rest-1.0
        /// </summary>
        public partial class ConversationMember
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string[]? Roles { get; set; }
            public DateTimeOffset? VisibleHistoryStartDateTime { get; set; }
        }

        public ConversationMember[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListMembersResponse> TeamListMembersAsync()
        {
            var p = new TeamListMembersParameter();
            return await this.SendAsync<TeamListMembersParameter, TeamListMembersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListMembersResponse> TeamListMembersAsync(CancellationToken cancellationToken)
        {
            var p = new TeamListMembersParameter();
            return await this.SendAsync<TeamListMembersParameter, TeamListMembersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListMembersResponse> TeamListMembersAsync(TeamListMembersParameter parameter)
        {
            return await this.SendAsync<TeamListMembersParameter, TeamListMembersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-members?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListMembersResponse> TeamListMembersAsync(TeamListMembersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamListMembersParameter, TeamListMembersResponse>(parameter, cancellationToken);
        }
    }
}
