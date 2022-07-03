using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-defaultmanagedappprotection?view=graph-rest-1.0
    /// </summary>
    public partial class DefaultManagedAppProtection
    {
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
        public string PeriodOfflineBeforeAccessCheck { get; set; }
        public string PeriodOnlineBeforeAccessCheck { get; set; }
        public DefaultManagedAppProtectionManagedAppDataTransferLevel AllowedInboundDataTransferSources { get; set; }
        public DefaultManagedAppProtectionManagedAppDataTransferLevel AllowedOutboundDataTransferDestinations { get; set; }
        public bool OrganizationalCredentialsRequired { get; set; }
        public DefaultManagedAppProtectionManagedAppClipboardSharingLevel AllowedOutboundClipboardSharingLevel { get; set; }
        public bool DataBackupBlocked { get; set; }
        public bool DeviceComplianceRequired { get; set; }
        public bool ManagedBrowserToOpenLinksRequired { get; set; }
        public bool SaveAsBlocked { get; set; }
        public string PeriodOfflineBeforeWipeIsEnforced { get; set; }
        public bool PinRequired { get; set; }
        public Int32? MaximumPinRetries { get; set; }
        public bool SimplePinBlocked { get; set; }
        public Int32? MinimumPinLength { get; set; }
        public DefaultManagedAppProtectionManagedAppPinCharacterSet PinCharacterSet { get; set; }
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
        public DefaultManagedAppProtectionManagedBrowserType ManagedBrowser { get; set; }
        public DefaultManagedAppProtectionManagedAppDataEncryptionType AppDataEncryptionType { get; set; }
        public bool ScreenCaptureBlocked { get; set; }
        public bool EncryptAppData { get; set; }
        public bool DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
        public string MinimumRequiredSdkVersion { get; set; }
        public KeyValuePair[] CustomSettings { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public string MinimumRequiredPatchVersion { get; set; }
        public string MinimumWarningPatchVersion { get; set; }
        public bool FaceIdBlocked { get; set; }
    }
}
