using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkGetInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        public string AppInstallationId { get; set; }
    }
    public partial class UserteamworkGetInstalledappsResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync()
        {
            var p = new UserteamworkGetInstalledappsParameter();
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkGetInstalledappsParameter();
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(UserteamworkGetInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async Task<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(UserteamworkGetInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
