using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamPostInstalledappsParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? TeamsApp { get; set; }
        public string TeamId { get; set; }
    }
    public partial class TeamPostInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync()
        {
            var p = new TeamPostInstalledappsParameter();
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamPostInstalledappsParameter();
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(TeamPostInstalledappsParameter parameter)
        {
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamPostInstalledappsResponse> TeamPostInstalledappsAsync(TeamPostInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamPostInstalledappsParameter, TeamPostInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
