using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class UserteamworkGetInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class UserteamworkGetInstalledappsResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public TeamsApp? TeamsApp { get; set; }
        public TeamsAppDefinition? TeamsAppDefinition { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync()
        {
            var p = new UserteamworkGetInstalledappsParameter();
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(CancellationToken cancellationToken)
        {
            var p = new UserteamworkGetInstalledappsParameter();
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(UserteamworkGetInstalledappsParameter parameter)
        {
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/userteamwork-get-installedapps?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserteamworkGetInstalledappsResponse> UserteamworkGetInstalledappsAsync(UserteamworkGetInstalledappsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserteamworkGetInstalledappsParameter, UserteamworkGetInstalledappsResponse>(parameter, cancellationToken);
        }
    }
}
