using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamDeleteInstalledappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_InstalledApps_AppInstallationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_InstalledApps_AppInstallationId: return $"/teams/{TeamId}/installedApps/{AppInstallationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string TeamId { get; set; }
        public string AppInstallationId { get; set; }
    }
    public partial class TeamDeleteInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteInstalledappsResponse> TeamDeleteInstalledappsAsync()
        {
            var p = new TeamDeleteInstalledappsParameter();
            return await this.SendAsync<TeamDeleteInstalledappsParameter, TeamDeleteInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteInstalledappsResponse> TeamDeleteInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new TeamDeleteInstalledappsParameter();
            return await this.SendAsync<TeamDeleteInstalledappsParameter, TeamDeleteInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteInstalledappsResponse> TeamDeleteInstalledappsAsync(TeamDeleteInstalledappsParameter parameter)
        {
            return await this.SendAsync<TeamDeleteInstalledappsParameter, TeamDeleteInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamDeleteInstalledappsResponse> TeamDeleteInstalledappsAsync(TeamDeleteInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamDeleteInstalledappsParameter, TeamDeleteInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
