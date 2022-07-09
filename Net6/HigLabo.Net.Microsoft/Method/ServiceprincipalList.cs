using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ServiceprincipalListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals: return $"/servicePrincipals";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AccountEnabled,
            AddIns,
            AlternativeNames,
            AppDescription,
            AppDisplayName,
            AppId,
            ApplicationTemplateId,
            AppOwnerOrganizationId,
            AppRoleAssignmentRequired,
            AppRoles,
            DeletedDateTime,
            Description,
            DisabledByMicrosoftStatus,
            DisplayName,
            Homepage,
            Id,
            Info,
            KeyCredentials,
            LoginUrl,
            LogoutUrl,
            Notes,
            NotificationEmailAddresses,
            Oauth2PermissionScopes,
            PasswordCredentials,
            PreferredSingleSignOnMode,
            ReplyUrls,
            ResourceSpecificApplicationPermissions,
            SamlSingleSignOnSettings,
            ServicePrincipalNames,
            ServicePrincipalType,
            SignInAudience,
            Tags,
            TokenEncryptionKeyId,
            VerifiedPublisher,
            AppRoleAssignedTo,
            AppRoleAssignments,
            ClaimsMappingPolicies,
            CreatedObjects,
            HomeRealmDiscoveryPolicies,
            MemberOf,
            Oauth2PermissionGrants,
            OwnedObjects,
            Owners,
            TokenIssuancePolicies,
            TokenLifetimePolicies,
        }
        public enum ApiPath
        {
            ServicePrincipals,
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
    public partial class ServiceprincipalListResponse : RestApiResponse
    {
        public ServicePrincipal[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListResponse> ServiceprincipalListAsync()
        {
            var p = new ServiceprincipalListParameter();
            return await this.SendAsync<ServiceprincipalListParameter, ServiceprincipalListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListResponse> ServiceprincipalListAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalListParameter();
            return await this.SendAsync<ServiceprincipalListParameter, ServiceprincipalListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListResponse> ServiceprincipalListAsync(ServiceprincipalListParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalListParameter, ServiceprincipalListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/serviceprincipal-list?view=graph-rest-1.0
        /// </summary>
        public async Task<ServiceprincipalListResponse> ServiceprincipalListAsync(ServiceprincipalListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalListParameter, ServiceprincipalListResponse>(parameter, cancellationToken);
        }
    }
}
