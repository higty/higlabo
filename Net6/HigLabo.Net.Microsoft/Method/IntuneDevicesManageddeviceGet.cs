using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDevicesManageddeviceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Users_UsersId_ManagedDevices_ManagedDeviceId,
            DeviceManagement_ManagedDevices_ManagedDeviceId,
            DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_UsersId_ManagedDevices_ManagedDeviceId: return $"/users/{UsersId}/managedDevices/{ManagedDeviceId}";
                    case ApiPath.DeviceManagement_ManagedDevices_ManagedDeviceId: return $"/deviceManagement/managedDevices/{ManagedDeviceId}";
                    case ApiPath.DeviceManagement_DetectedApps_DetectedAppId_ManagedDevices_ManagedDeviceId: return $"/deviceManagement/detectedApps/{DetectedAppId}/managedDevices/{ManagedDeviceId}";
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
        public string UsersId { get; set; }
        public string ManagedDeviceId { get; set; }
        public string DetectedAppId { get; set; }
    }
    public partial class IntuneDevicesManageddeviceGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceGetResponse> IntuneDevicesManageddeviceGetAsync()
        {
            var p = new IntuneDevicesManageddeviceGetParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceGetParameter, IntuneDevicesManageddeviceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceGetResponse> IntuneDevicesManageddeviceGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDevicesManageddeviceGetParameter();
            return await this.SendAsync<IntuneDevicesManageddeviceGetParameter, IntuneDevicesManageddeviceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceGetResponse> IntuneDevicesManageddeviceGetAsync(IntuneDevicesManageddeviceGetParameter parameter)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceGetParameter, IntuneDevicesManageddeviceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-devices-manageddevice-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDevicesManageddeviceGetResponse> IntuneDevicesManageddeviceGetAsync(IntuneDevicesManageddeviceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDevicesManageddeviceGetParameter, IntuneDevicesManageddeviceGetResponse>(parameter, cancellationToken);
        }
    }
}
