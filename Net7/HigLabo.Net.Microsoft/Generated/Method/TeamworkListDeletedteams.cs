using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public partial class TeamworkListDeletedteamsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teamwork_DeletedTeams: return $"/teamwork/deletedTeams";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            Channels,
        }
        public enum ApiPath
        {
            Teamwork_DeletedTeams,
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
    public partial class TeamworkListDeletedteamsResponse : RestApiResponse
    {
        public DeletedTeam[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworkListDeletedteamsResponse> TeamworkListDeletedteamsAsync()
        {
            var p = new TeamworkListDeletedteamsParameter();
            return await this.SendAsync<TeamworkListDeletedteamsParameter, TeamworkListDeletedteamsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworkListDeletedteamsResponse> TeamworkListDeletedteamsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamworkListDeletedteamsParameter();
            return await this.SendAsync<TeamworkListDeletedteamsParameter, TeamworkListDeletedteamsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworkListDeletedteamsResponse> TeamworkListDeletedteamsAsync(TeamworkListDeletedteamsParameter parameter)
        {
            return await this.SendAsync<TeamworkListDeletedteamsParameter, TeamworkListDeletedteamsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/teamwork-list-deletedteams?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamworkListDeletedteamsResponse> TeamworkListDeletedteamsAsync(TeamworkListDeletedteamsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamworkListDeletedteamsParameter, TeamworkListDeletedteamsResponse>(parameter, cancellationToken);
        }
    }
}
