using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkDeleteInstalledappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps_AppInstallationId: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps/{AppInstallationId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UserIdOrUserPrincipalName { get; set; }
        public string AppInstallationId { get; set; }
    }
    public partial class UserteamworkDeleteInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync()
        {
            var p = new UserteamworkDeleteInstalledappsParameter();
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkDeleteInstalledappsParameter();
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(UserteamworkDeleteInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-delete-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkDeleteInstalledappsResponse> UserteamworkDeleteInstalledappsAsync(UserteamworkDeleteInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkDeleteInstalledappsParameter, UserteamworkDeleteInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
