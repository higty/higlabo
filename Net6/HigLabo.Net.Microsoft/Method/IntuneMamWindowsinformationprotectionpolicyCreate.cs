using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamWindowsinformationprotectionpolicyCreateParameter : IRestApiParameter
    {
        public enum IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionEnforcementLevel
        {
            NoProtection,
            EncryptAndAuditOnly,
            EncryptAuditAndPrompt,
            EncryptAuditAndBlock,
        }
        public enum IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionPinCharacterRequirements
        {
            NotAllow,
            RequireAtLeastOne,
            Allow,
        }
        public enum ApiPath
        {
            DeviceAppManagement_WindowsInformationProtectionPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_WindowsInformationProtectionPolicies: return $"/deviceAppManagement/windowsInformationProtectionPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionEnforcementLevel EnforcementLevel { get; set; }
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
        public IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionPinCharacterRequirements PinUppercaseLetters { get; set; }
        public IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionPinCharacterRequirements PinLowercaseLetters { get; set; }
        public IntuneMamWindowsinformationprotectionpolicyCreateParameterWindowsInformationProtectionPinCharacterRequirements PinSpecialCharacters { get; set; }
        public Int32? PinExpirationDays { get; set; }
        public Int32? NumberOfPastPinsRemembered { get; set; }
        public Int32? PasswordMaximumAttemptCount { get; set; }
        public Int32? MinutesOfInactivityBeforeDeviceLock { get; set; }
        public Int32? DaysWithoutContactBeforeUnenroll { get; set; }
    }
    public partial class IntuneMamWindowsinformationprotectionpolicyCreateResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyCreateResponse> IntuneMamWindowsinformationprotectionpolicyCreateAsync()
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyCreateParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyCreateParameter, IntuneMamWindowsinformationprotectionpolicyCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyCreateResponse> IntuneMamWindowsinformationprotectionpolicyCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamWindowsinformationprotectionpolicyCreateParameter();
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyCreateParameter, IntuneMamWindowsinformationprotectionpolicyCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyCreateResponse> IntuneMamWindowsinformationprotectionpolicyCreateAsync(IntuneMamWindowsinformationprotectionpolicyCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyCreateParameter, IntuneMamWindowsinformationprotectionpolicyCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-windowsinformationprotectionpolicy-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamWindowsinformationprotectionpolicyCreateResponse> IntuneMamWindowsinformationprotectionpolicyCreateAsync(IntuneMamWindowsinformationprotectionpolicyCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamWindowsinformationprotectionpolicyCreateParameter, IntuneMamWindowsinformationprotectionpolicyCreateResponse>(parameter, cancellationToken);
        }
    }
}
