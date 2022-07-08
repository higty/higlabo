using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserteamworkListInstalledappsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UserIdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps: return $"/users/{UserIdOrUserPrincipalName}/teamwork/installedApps";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Id,
            TeamsApp,
            TeamsAppDefinition,
        }
        public enum ApiPath
        {
            Users_UserIdOrUserPrincipalName_Teamwork_InstalledApps,
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
    public partial class UserteamworkListInstalledappsResponse : RestApiResponse
    {
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
