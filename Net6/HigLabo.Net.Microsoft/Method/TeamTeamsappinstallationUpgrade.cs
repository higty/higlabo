using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class TeamTeamsappinstallationUpgradeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Teams_TeamId_InstalledApps_AppInstallationId_Upgrade,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Teams_TeamId_InstalledApps_AppInstallationId_Upgrade: return $"/teams/{TeamId}/installedApps/{AppInstallationId}/upgrade";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string TeamId { get; set; }
        public string AppInstallationId { get; set; }
    }
    public partial class TeamTeamsappinstallationUpgradeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync()
        {
            var p = new TeamTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(CancellationToken cancellationToken)
        {
            var p = new TeamTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(TeamTeamsappinstallationUpgradeParameter parameter)
        {
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(TeamTeamsappinstallationUpgradeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(parameter, cancellationToken);
        }
    }
}
