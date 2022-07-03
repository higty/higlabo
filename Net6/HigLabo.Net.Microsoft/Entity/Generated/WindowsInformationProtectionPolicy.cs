using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionPolicy
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
        public WindowsInformationProtectionPolicyWindowsInformationProtectionEnforcementLevel EnforcementLevel { get; set; }
        public string EnterpriseDomain { get; set; }
        public WindowsInformationProtectionResourceCollection[] EnterpriseProtectedDomainNames { get; set; }
        public bool ProtectionUnderLockConfigRequired { get; set; }
        public WindowsInformationProtectionDataRecoveryCertificate? DataRecoveryCertificate { get; set; }
        public bool RevokeOnUnenrollDisabled { get; set; }
        public Guid? RightsManagementServicesTemplateId { get; set; }
        public bool AzureRightsManagementServicesAllowed { get; set; }
        public bool IconsVisible { get; set; }
        public WindowsInformationProtectionApp[] ProtectedApps { get; set; }
        public WindowsInformationProtectionApp[] ExemptApps { get; set; }
        public WindowsInformationProtectionResourceCollection[] EnterpriseNetworkDomainNames { get; set; }
        public WindowsInformationProtectionProxiedDomainCollection[] EnterpriseProxiedDomains { get; set; }
        public WindowsInformationProtectionIPRangeCollection[] EnterpriseIPRanges { get; set; }
        public bool EnterpriseIPRangesAreAuthoritative { get; set; }
        public WindowsInformationProtectionResourceCollection[] EnterpriseProxyServers { get; set; }
        public WindowsInformationProtectionResourceCollection[] EnterpriseInternalProxyServers { get; set; }
        public bool EnterpriseProxyServersAreAuthoritative { get; set; }
        public WindowsInformationProtectionResourceCollection[] NeutralDomainResources { get; set; }
        public bool IndexingEncryptedStoresOrItemsBlocked { get; set; }
        public WindowsInformationProtectionResourceCollection[] SmbAutoEncryptedFileExtensions { get; set; }
        public bool IsAssigned { get; set; }
        public bool RevokeOnMdmHandoffDisabled { get; set; }
        public string MdmEnrollmentUrl { get; set; }
        public bool WindowsHelloForBusinessBlocked { get; set; }
        public Int32? PinMinimumLength { get; set; }
        public WindowsInformationProtectionPolicyWindowsInformationProtectionPinCharacterRequirements PinUppercaseLetters { get; set; }
        public WindowsInformationProtectionPolicyWindowsInformationProtectionPinCharacterRequirements PinLowercaseLetters { get; set; }
        public WindowsInformationProtectionPolicyWindowsInformationProtectionPinCharacterRequirements PinSpecialCharacters { get; set; }
        public Int32? PinExpirationDays { get; set; }
        public Int32? NumberOfPastPinsRemembered { get; set; }
        public Int32? PasswordMaximumAttemptCount { get; set; }
        public Int32? MinutesOfInactivityBeforeDeviceLock { get; set; }
        public Int32? DaysWithoutContactBeforeUnenroll { get; set; }
    }
}
