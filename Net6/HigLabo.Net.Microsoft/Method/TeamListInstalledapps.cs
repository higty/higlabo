using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Teams_TeamId_InstalledApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_InstalledApps: return $"/teams/{TeamId}/installedApps";
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
    public partial class TeamListInstalledappsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/teamsappinstallation?view=graph-rest-1.0
        /// </summary>
        public partial class TeamsAppInstallation
        {
            public string? Id { get; set; }
        }

        public TeamsAppInstallation[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListInstalledappsResponse> TeamListInstalledappsAsync()
        {
            var p = new TeamListInstalledappsParameter();
            return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListInstalledappsResponse> TeamListInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamListInstalledappsParameter();
            return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListInstalledappsResponse> TeamListInstalledappsAsync(TeamListInstalledappsParameter parameter)
        {
            return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamListInstalledappsResponse> TeamListInstalledappsAsync(TeamListInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamListInstalledappsParameter, TeamListInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
