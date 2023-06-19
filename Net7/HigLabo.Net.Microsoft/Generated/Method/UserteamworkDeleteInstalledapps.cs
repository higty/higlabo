using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class UserteamworkDeleteInstalledappsParameter : IRestApiParameter
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
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class UserteamworkDeleteInstalledappsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync()
        {
            var p = new UserteamworkDeleteInstalledappsParameter();
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkDeleteInstalledappsParameter();
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(UserteamworkDeleteInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(UserteamworkDeleteInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
