using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class UserSettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Me_Settings_: return $"/me/settings/";
                    case ApiPath.Users_IdOrUserPrincipalName_Settings_: return $"/users/{IdOrUserPrincipalName}/settings/";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Me_Settings_,
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
    public partial class UserSettingsGetResponse : RestApiResponse
    {
        public bool? ContributionToContentDiscoveryAsOrganizationDisabled { get; set; }
        public bool? ContributionToContentDiscoveryDisabled { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsGetResponse> UserSettingsGetAsync()
        {
            var p = new UserSettingsGetParameter();
            return await this.SendAsync<UserSettingsGetParameter, UserSettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsGetResponse> UserSettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new UserSettingsGetParameter();
            return await this.SendAsync<UserSettingsGetParameter, UserSettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsGetResponse> UserSettingsGetAsync(UserSettingsGetParameter parameter)
        {
            return await this.SendAsync<UserSettingsGetParameter, UserSettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/usersettings-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UserSettingsGetResponse> UserSettingsGetAsync(UserSettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserSettingsGetParameter, UserSettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
