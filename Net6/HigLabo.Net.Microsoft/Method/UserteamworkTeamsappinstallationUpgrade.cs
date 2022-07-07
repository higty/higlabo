using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkTeamsappinstallationUpgradeParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Upgrade,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId_Upgrade: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}/upgrade";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string UserIdOrUserPrincipalName { get; set; }
        public string AppInstallationId { get; set; }
    }
    public partial class UserteamworkTeamsappinstallationUpgradeResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync()
        {
            var p = new UserteamworkTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkTeamsappinstallationUpgradeParameter();
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(UserteamworkTeamsappinstallationUpgradeParameter parameter)
        {
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-teamsappinstallation-upgrade?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkTeamsappinstallationUpgradeResponse> UserteamworkTeamsappinstallationUpgradeAsync(UserteamworkTeamsappinstallationUpgradeParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkTeamsappinstallationUpgradeParameter, UserteamworkTeamsappinstallationUpgradeResponse>(parameter, cancellationToken);
        }
    }
}
