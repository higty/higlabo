using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public partial class ServiceprincipalDeltaParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.ServicePrincipals_Delta: return $"/servicePrincipals/delta";
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
            PreferredTokenSigningKeyThumbprint,
            ReplyUrls,
            ResourceSpecificApplicationPermissions,
            SamlSingleSignOnSettings,
            ServicePrincipalNames,
            ServicePrincipalType,
            SignInAudience,
            Tags,
            TokenEncryptionKeyId,
            VerifiedPublisher,
            AppManagementPolicies,
            AppRoleAssignedTo,
            AppRoleAssignments,
            ClaimsMappingPolicies,
            CreatedObjects,
            FederatedIdentityCredentials,
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
            ServicePrincipals_Delta,
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
    public partial class ServiceprincipalDeltaResponse : RestApiResponse
    {
        public ServicePrincipal[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeltaResponse> ServiceprincipalDeltaAsync()
        {
            var p = new ServiceprincipalDeltaParameter();
            return await this.SendAsync<ServiceprincipalDeltaParameter, ServiceprincipalDeltaResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeltaResponse> ServiceprincipalDeltaAsync(CancellationToken cancellationToken)
        {
            var p = new ServiceprincipalDeltaParameter();
            return await this.SendAsync<ServiceprincipalDeltaParameter, ServiceprincipalDeltaResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeltaResponse> ServiceprincipalDeltaAsync(ServiceprincipalDeltaParameter parameter)
        {
            return await this.SendAsync<ServiceprincipalDeltaParameter, ServiceprincipalDeltaResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/serviceprincipal-delta?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ServiceprincipalDeltaResponse> ServiceprincipalDeltaAsync(ServiceprincipalDeltaParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ServiceprincipalDeltaParameter, ServiceprincipalDeltaResponse>(parameter, cancellationToken);
        }
    }
}
