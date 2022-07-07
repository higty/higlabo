using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string UserIdOrUserPrincipalName { get; set; }
    }
    public partial class UserteamworkListInstalledappsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkListInstalledappsResponse> UserteamworkListInstalledappsAsync()
        {
            var p = new UserteamworkListInstalledappsParameter();
            return await this.SendAsync<UserteamworkListInstalledappsParameter, UserteamworkListInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkListInstalledappsResponse> UserteamworkListInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkListInstalledappsParameter();
            return await this.SendAsync<UserteamworkListInstalledappsParameter, UserteamworkListInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkListInstalledappsResponse> UserteamworkListInstalledappsAsync(UserteamworkListInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkListInstalledappsParameter, UserteamworkListInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-list-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkListInstalledappsResponse> UserteamworkListInstalledappsAsync(UserteamworkListInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkListInstalledappsParameter, UserteamworkListInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
