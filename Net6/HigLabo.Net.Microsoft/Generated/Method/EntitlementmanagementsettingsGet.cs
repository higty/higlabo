using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementSettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Settings: return $"/identityGovernance/entitlementManagement/settings";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            DurationUntilExternalUserDeletedAfterBlocked,
            ExternalUserLifecycleAction,
            Id,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Settings,
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
    public partial class EntitlementManagementSettingsGetResponse : RestApiResponse
    {
        public enum EntitlementManagementSettingsAccessPackageExternalUserLifecycleAction
        {
            None,
            BlockSignIn,
            BlockSignInAndDelete,
            UnknownFutureValue,
        }

        public string? DurationUntilExternalUserDeletedAfterBlocked { get; set; }
        public EntitlementManagementSettingsAccessPackageExternalUserLifecycleAction ExternalUserLifecycleAction { get; set; }
        public string? Id { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsGetResponse> EntitlementManagementSettingsGetAsync()
        {
            var p = new EntitlementManagementSettingsGetParameter();
            return await this.SendAsync<EntitlementManagementSettingsGetParameter, EntitlementManagementSettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsGetResponse> EntitlementManagementSettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementSettingsGetParameter();
            return await this.SendAsync<EntitlementManagementSettingsGetParameter, EntitlementManagementSettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsGetResponse> EntitlementManagementSettingsGetAsync(EntitlementManagementSettingsGetParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementSettingsGetParameter, EntitlementManagementSettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementSettingsGetResponse> EntitlementManagementSettingsGetAsync(EntitlementManagementSettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementSettingsGetParameter, EntitlementManagementSettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
