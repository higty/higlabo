using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-iosmanagedappprotection?view=graph-rest-1.0
    /// </summary>
    public partial class IosManagedAppProtection
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
        public string PeriodOfflineBeforeAccessCheck { get; set; }
        public string PeriodOnlineBeforeAccessCheck { get; set; }
        public IosManagedAppProtectionManagedAppDataTransferLevel AllowedInboundDataTransferSources { get; set; }
        public IosManagedAppProtectionManagedAppDataTransferLevel AllowedOutboundDataTransferDestinations { get; set; }
        public bool OrganizationalCredentialsRequired { get; set; }
        public IosManagedAppProtectionManagedAppClipboardSharingLevel AllowedOutboundClipboardSharingLevel { get; set; }
        public bool DataBackupBlocked { get; set; }
        public bool DeviceComplianceRequired { get; set; }
        public bool ManagedBrowserToOpenLinksRequired { get; set; }
        public bool SaveAsBlocked { get; set; }
        public string PeriodOfflineBeforeWipeIsEnforced { get; set; }
        public bool PinRequired { get; set; }
        public Int32? MaximumPinRetries { get; set; }
        public bool SimplePinBlocked { get; set; }
        public Int32? MinimumPinLength { get; set; }
        public IosManagedAppProtectionManagedAppPinCharacterSet PinCharacterSet { get; set; }
        public string PeriodBeforePinReset { get; set; }
        public ManagedAppDataStorageLocation[] AllowedDataStorageLocations { get; set; }
        public bool ContactSyncBlocked { get; set; }
        public bool PrintBlocked { get; set; }
        public bool FingerprintBlocked { get; set; }
        public bool DisableAppPinIfDevicePinIsSet { get; set; }
        public string MinimumRequiredOsVersion { get; set; }
        public string MinimumWarningOsVersion { get; set; }
        public string MinimumRequiredAppVersion { get; set; }
        public string MinimumWarningAppVersion { get; set; }
        public IosManagedAppProtectionManagedBrowserType ManagedBrowser { get; set; }
        public bool IsAssigned { get; set; }
        public IosManagedAppProtectionManagedAppDataEncryptionType AppDataEncryptionType { get; set; }
        public string MinimumRequiredSdkVersion { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public bool FaceIdBlocked { get; set; }
        public string CustomBrowserProtocol { get; set; }
    }
}
