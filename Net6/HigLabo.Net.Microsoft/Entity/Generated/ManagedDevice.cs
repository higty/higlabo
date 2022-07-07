using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-manageddevice?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedDevice
    {
        public enum ManagedDeviceManagedDeviceOwnerType
        {
            Unknown,
            Company,
            Personal,
        }
        public enum ManagedDeviceComplianceState
        {
            Unknown,
            Compliant,
            Noncompliant,
            Conflict,
            Error,
            InGracePeriod,
            ConfigManager,
        }
        public enum ManagedDeviceManagementAgentType
        {
            Eas,
            Mdm,
            EasMdm,
            IntuneClient,
            EasIntuneClient,
            ConfigurationManagerClient,
            ConfigurationManagerClientMdm,
            ConfigurationManagerClientMdmEas,
            Unknown,
            Jamf,
            GoogleCloudDevicePolicyController,
        }
        public enum ManagedDeviceDeviceEnrollmentType
        {
            Unknown,
            UserEnrollment,
            DeviceEnrollmentManager,
            AppleBulkWithUser,
            AppleBulkWithoutUser,
            WindowsAzureADJoin,
            WindowsBulkUserless,
            WindowsAutoEnrollment,
            WindowsBulkAzureDomainJoin,
            WindowsCoManagement,
            WindowsAzureADJoinUsingDeviceAuth,
            AppleUserEnrollment,
            AppleUserEnrollmentWithServiceAccount,
        }
        public enum ManagedDeviceDeviceRegistrationState
        {
            NotRegistered,
            Registered,
            Revoked,
            KeyConflict,
            ApprovalPending,
            CertificateReset,
            NotRegisteredPendingEnrollment,
            Unknown,
        }
        public enum ManagedDeviceDeviceManagementExchangeAccessState
        {
            None,
            Unknown,
            Allowed,
            Blocked,
            Quarantined,
        }
        public enum ManagedDeviceDeviceManagementExchangeAccessStateReason
        {
            None,
            Unknown,
            ExchangeGlobalRule,
            ExchangeIndividualRule,
            ExchangeDeviceRule,
            ExchangeUpgrade,
            ExchangeMailboxPolicy,
            Other,
            Compliant,
            NotCompliant,
            NotEnrolled,
            UnknownLocation,
            MfaRequired,
            AzureADBlockDueToAccessPolicy,
            CompromisedPassword,
            DeviceNotKnownWithManagedApp,
        }
        public enum ManagedDeviceManagedDevicePartnerReportedHealthState
        {
            Unknown,
            Activated,
            Deactivated,
            Secured,
            LowSeverity,
            MediumSeverity,
            HighSeverity,
            Unresponsive,
            Compromised,
            Misconfigured,
        }

        public string? Id { get; set; }
        public string? UserId { get; set; }
        public string? DeviceName { get; set; }
        public ManagedDeviceOwnerType? ManagedDeviceOwnerType { get; set; }
        public DeviceActionResult[]? DeviceActionResults { get; set; }
        public DateTimeOffset? EnrolledDateTime { get; set; }
        public DateTimeOffset? LastSyncDateTime { get; set; }
        public string? OperatingSystem { get; set; }
        public ComplianceState? ComplianceState { get; set; }
        public string? JailBroken { get; set; }
        public ManagementAgentType? ManagementAgent { get; set; }
        public string? OsVersion { get; set; }
        public bool? EasActivated { get; set; }
        public string? EasDeviceId { get; set; }
        public DateTimeOffset? EasActivationDateTime { get; set; }
        public bool? AzureADRegistered { get; set; }
        public DeviceEnrollmentType? DeviceEnrollmentType { get; set; }
        public string? ActivationLockBypassCode { get; set; }
        public string? EmailAddress { get; set; }
        public string? AzureADDeviceId { get; set; }
        public DeviceRegistrationState? DeviceRegistrationState { get; set; }
        public string? DeviceCategoryDisplayName { get; set; }
        public bool? IsSupervised { get; set; }
        public DateTimeOffset? ExchangeLastSuccessfulSyncDateTime { get; set; }
        public DeviceManagementExchangeAccessState? ExchangeAccessState { get; set; }
        public DeviceManagementExchangeAccessStateReason? ExchangeAccessStateReason { get; set; }
        public string? RemoteAssistanceSessionUrl { get; set; }
        public string? RemoteAssistanceSessionErrorDetails { get; set; }
        public bool? IsEncrypted { get; set; }
        public string? UserPrincipalName { get; set; }
        public string? Model { get; set; }
        public string? Manufacturer { get; set; }
        public string? Imei { get; set; }
        public DateTimeOffset? ComplianceGracePeriodExpirationDateTime { get; set; }
        public string? SerialNumber { get; set; }
        public string? PhoneNumber { get; set; }
        public string? AndroidSecurityPatchLevel { get; set; }
        public string? UserDisplayName { get; set; }
        public ConfigurationManagerClientEnabledFeatures? ConfigurationManagerClientEnabledFeatures { get; set; }
        public string? WiFiMacAddress { get; set; }
        public DeviceHealthAttestationState? DeviceHealthAttestationState { get; set; }
        public string? SubscriberCarrier { get; set; }
        public string? Meid { get; set; }
        public Int64? TotalStorageSpaceInBytes { get; set; }
        public Int64? FreeStorageSpaceInBytes { get; set; }
        public string? ManagedDeviceName { get; set; }
        public ManagedDevicePartnerReportedHealthState? PartnerReportedThreatState { get; set; }
        public string? Iccid { get; set; }
        public string? Udid { get; set; }
        public string? Notes { get; set; }
        public string? EthernetMacAddress { get; set; }
        public Int64? PhysicalMemoryInBytes { get; set; }
    }
}
