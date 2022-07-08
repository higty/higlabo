using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserSettingsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Settings: return $"/me/settings";
                    case ApiPath.Users_IdOrUserPrincipalName_Settings_: return $"/users/{IdOrUserPrincipalName}/settings/";
                    case ApiPath.Ttps__Graphmicrosoftcom_V10_Me_Settings: return $"/ttps://graph.microsoft.com/v1.0/me/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Settings,
            Users_IdOrUserPrincipalName_Settings_,
            Ttps__Graphmicrosoftcom_V10_Me_Settings,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public bool? ContributionToContentDiscoveryDisabled { get; set; }
    }
    public partial class UserSettingsUpdateResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSettingsUpdateResponse> UserSettingsUpdateAsync()
        {
            var p = new UserSettingsUpdateParameter();
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSettingsUpdateResponse> UserSettingsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new UserSettingsUpdateParameter();
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSettingsUpdateResponse> UserSettingsUpdateAsync(UserSettingsUpdateParameter parameter)
        {
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UserSettingsUpdateResponse> UserSettingsUpdateAsync(UserSettingsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
