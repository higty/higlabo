using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
    /// </summary>
    public partial class UserteamworkTeamsappinstallationUpgradeParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UserIdOrUserPrincipalName { get; set; }
            public string? AppInstallationId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Upgrade: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}/upgrade";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Upgrade,
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
    public partial class UserteamworkTeamsappinstallationUpgradeResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync()
        {
            var p = new UserteamworkTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(UserteamworkTeamsappinstallationUpgradeParameter parameter)
        {
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(UserteamworkTeamsappinstallationUpgradeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(parameter, cancellationToken);
        }
    }
}
