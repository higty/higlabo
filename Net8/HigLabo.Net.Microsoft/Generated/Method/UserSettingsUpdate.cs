using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
    /// </summary>
    public partial class UserSettingsUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Settings: return $"/me/settings";
                    case ApiPath.Users_IdOrUserPrincipalName_Settings_: return $"/users/{IdOrUserPrincipalName}/settings/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Me_Settings,
            Users_IdOrUserPrincipalName_Settings_,
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsUpdateResponse> UserSettingsUpdateAsync()
        {
            var p = new UserSettingsUpdateParameter();
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsUpdateResponse> UserSettingsUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new UserSettingsUpdateParameter();
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsUpdateResponse> UserSettingsUpdateAsync(UserSettingsUpdateParameter parameter)
        {
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsUpdateResponse> UserSettingsUpdateAsync(UserSettingsUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserSettingsUpdateParameter, UserSettingsUpdateResponse>(parameter, cancellationToken);
        }
    }
}
