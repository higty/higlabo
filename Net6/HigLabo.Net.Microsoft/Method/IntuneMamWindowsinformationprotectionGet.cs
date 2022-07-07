using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppPolicies/{ManagedAppPolicyId}";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies/{ManagedAppPolicyId}";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies_ManagedAppPolicyId: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies/{ManagedAppPolicyId}";
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
        public string ManagedAppPolicyId { get; set; }
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionGetResponse : RestApiResponse
    {
        public enum WindowsInformationProtectionWindowsInformationProtectionEnforcementLevel
        {
            NoProtection,
            EncryptAndAuditOnly,
            EncryptAuditAndPrompt,
            EncryptAuditAndBlock,
        }

        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public WindowsInformationProtectionEnforcementLevel? EnforcementLevel { get; set; }
        public string? EnterpriseDomain { get; set; }
        public WindowsInformationProtectionResourceCollection[]? EnterpriseProtectedDomainNames { get; set; }
        public bool? ProtectionUnderLockConfigRequired { get; set; }
        public WindowsInformationProtectionDataRecoveryCertificate? DataRecoveryCertificate { get; set; }
        public bool? RevokeOnUnenrollDisabled { get; set; }
        public Guid? RightsManagementServicesTemplateId { get; set; }
        public bool? AzureRightsManagementServicesAllowed { get; set; }
        public bool? IconsVisible { get; set; }
        public WindowsInformationProtectionApp[]? ProtectedApps { get; set; }
        public WindowsInformationProtectionApp[]? ExemptApps { get; set; }
        public WindowsInformationProtectionResourceCollection[]? EnterpriseNetworkDomainNames { get; set; }
        public WindowsInformationProtectionProxiedDomainCollection[]? EnterpriseProxiedDomains { get; set; }
        public WindowsInformationProtectionIPRangeCollection[]? EnterpriseIPRanges { get; set; }
        public bool? EnterpriseIPRangesAreAuthoritative { get; set; }
        public WindowsInformationProtectionResourceCollection[]? EnterpriseProxyServers { get; set; }
        public WindowsInformationProtectionResourceCollection[]? EnterpriseInternalProxyServers { get; set; }
        public bool? EnterpriseProxyServersAreAuthoritative { get; set; }
        public WindowsInformationProtectionResourceCollection[]? NeutralDomainResources { get; set; }
        public bool? IndexingEncryptedStoresOrItemsBlocked { get; set; }
        public WindowsInformationProtectionResourceCollection[]? SmbAutoEncryptedFileExtensions { get; set; }
        public bool? IsAssigned { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionGetResponse> IntuneMamWindowsinformationprotectionGetAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionGetParameter, IntuneMamWindowsinformationprotectionGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionGetResponse> IntuneMamWindowsinformationprotectionGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionGetParameter, IntuneMamWindowsinformationprotectionGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionGetResponse> IntuneMamWindowsinformationprotectionGetAsync(IntuneMamWindowsinformationprotectionGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionGetParameter, IntuneMamWindowsinformationprotectionGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotection-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionGetResponse> IntuneMamWindowsinformationprotectionGetAsync(IntuneMamWindowsinformationprotectionGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionGetParameter, IntuneMamWindowsinformationprotectionGetResponse>(parameter, cancellationToken);
        }
    }
}
