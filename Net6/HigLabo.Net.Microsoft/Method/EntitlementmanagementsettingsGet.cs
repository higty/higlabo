using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementsettingsGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Settings,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Settings: return $"/identityGovernance/entitlementManagement/settings";
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
    }
    public partial class EntitlementmanagementsettingsGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementsettingsGetResponse> EntitlementmanagementsettingsGetAsync()
        {
            var p = new EntitlementmanagementsettingsGetParameter();
            return await this.SendAsync<EntitlementmanagementsettingsGetParameter, EntitlementmanagementsettingsGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementsettingsGetResponse> EntitlementmanagementsettingsGetAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementsettingsGetParameter();
            return await this.SendAsync<EntitlementmanagementsettingsGetParameter, EntitlementmanagementsettingsGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementsettingsGetResponse> EntitlementmanagementsettingsGetAsync(EntitlementmanagementsettingsGetParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementsettingsGetParameter, EntitlementmanagementsettingsGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagementsettings-get?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementsettingsGetResponse> EntitlementmanagementsettingsGetAsync(EntitlementmanagementsettingsGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementsettingsGetParameter, EntitlementmanagementsettingsGetResponse>(parameter, cancellationToken);
        }
    }
}
