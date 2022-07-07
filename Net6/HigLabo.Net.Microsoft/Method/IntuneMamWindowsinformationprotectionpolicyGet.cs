using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies_WindowsInformationProtectionPolicyId: return $"/deviceAppManagement/windowsInformationProtectionPolicies/{WindowsInformationProtectionPolicyId}";
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
        public string WindowsInformationProtectionPolicyId { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionpolicyGetResponse : RestApiResponse
    {
        public enum WindowsInformationProtectionPolicyWindowsInformationProtectionEnforcementLevel
        {
            NoProtection,
            EncryptAndAuditOnly,
            EncryptAuditAndPrompt,
            EncryptAuditAndBlock,
        }
        public enum WindowsInformationProtectionPolicyWindowsInformationProtectionPinCharacterRequirements
        {
            NotAllow,
            RequireAtLeastOne,
            Allow,
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
        public bool? RevokeOnMdmHandoffDisabled { get; set; }
        public string? MdmEnrollmentUrl { get; set; }
        public bool? WindowsHelloForBusinessBlocked { get; set; }
        public Int32? PinMinimumLength { get; set; }
        public WindowsInformationProtectionPinCharacterRequirements? PinUppercaseLetters { get; set; }
        public WindowsInformationProtectionPinCharacterRequirements? PinLowercaseLetters { get; set; }
        public WindowsInformationProtectionPinCharacterRequirements? PinSpecialCharacters { get; set; }
        public Int32? PinExpirationDays { get; set; }
        public Int32? NumberOfPastPinsRemembered { get; set; }
        public Int32? PasswordMaximumAttemptCount { get; set; }
        public Int32? MinutesOfInactivityBeforeDeviceLock { get; set; }
        public Int32? DaysWithoutContactBeforeUnenroll { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyGetResponse> IntuneMamWindowsinformationprotectionpolicyGetAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyGetParameter, IntuneMamWindowsinformationprotectionpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyGetResponse> IntuneMamWindowsinformationprotectionpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyGetParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyGetParameter, IntuneMamWindowsinformationprotectionpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyGetResponse> IntuneMamWindowsinformationprotectionpolicyGetAsync(IntuneMamWindowsinformationprotectionpolicyGetParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyGetParameter, IntuneMamWindowsinformationprotectionpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyGetResponse> IntuneMamWindowsinformationprotectionpolicyGetAsync(IntuneMamWindowsinformationprotectionpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyGetParameter, IntuneMamWindowsinformationprotectionpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
