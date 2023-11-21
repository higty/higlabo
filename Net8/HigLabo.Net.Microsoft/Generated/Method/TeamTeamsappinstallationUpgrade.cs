using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
    /// </summary>
    public partial class TeamTeamsappinstallationUpgradeParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? TeamId { get; set; }
            public string? AppInstallationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Teams_TeamId_InstalledApps_AppInstallationId_Upgrade: return $"/teams/{TeamId}/installedApps/{AppInstallationId}/upgrade";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Teams_TeamId_InstalledApps_AppInstallationId_Upgrade,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class TeamTeamsappinstallationUpgradeResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync()
        {
            var p = new TeamTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(CancellationToken cancellationToken)
        {
            var p = new TeamTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(TeamTeamsappinstallationUpgradeParameter parameter)
        {
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/team-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TeamTeamsappinstallationUpgradeResponse> TeamTeamsappinstallationUpgradeAsync(TeamTeamsappinstallationUpgradeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TeamTeamsappinstallationUpgradeParameter, TeamTeamsappinstallationUpgradeResponse>(parameter, cancellationToken);
        }
    }
}
