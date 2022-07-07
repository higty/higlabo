using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkPostInstalledappsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? TeamsApp { get; set; }
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class UserteamworkPostInstalledappsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkPostInstalledappsResponse> UserteamworkPostInstalledappsAsync()
        {
            var p = new UserteamworkPostInstalledappsParameter();
            return await this.SendAsync<UserteamworkPostInstalledappsParameter, UserteamworkPostInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkPostInstalledappsResponse> UserteamworkPostInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkPostInstalledappsParameter();
            return await this.SendAsync<UserteamworkPostInstalledappsParameter, UserteamworkPostInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkPostInstalledappsResponse> UserteamworkPostInstalledappsAsync(UserteamworkPostInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkPostInstalledappsParameter, UserteamworkPostInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-post-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkPostInstalledappsResponse> UserteamworkPostInstalledappsAsync(UserteamworkPostInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkPostInstalledappsParameter, UserteamworkPostInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
