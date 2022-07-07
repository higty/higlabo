using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-androidgeneraldeviceconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class AndroidGeneralDeviceConfiguration
    {
        public enum AndroidGeneralDeviceConfigurationAppListType
        {
            None,
            AppsInListCompliant,
            AppsNotInListCompliant,
        }
        public enum AndroidGeneralDeviceConfigurationAndroidRequiredPasswordType
        {
            DeviceDefault,
            Alphabetic,
            Alphanumeric,
            AlphanumericWithSymbols,
            LowSecurityBiometric,
            Numeric,
            NumericComplex,
            Any,
        }
        public enum AndroidGeneralDeviceConfigurationWebBrowserCookieSettings
        {
            BrowserDefault,
            BlockAlways,
            AllowCurrentWebSite,
            AllowFromWebsitesVisited,
            AllowAlways,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? AppsBlockClipboardSharing { get; set; }
        public bool? AppsBlockCopyPaste { get; set; }
        public bool? AppsBlockYouTube { get; set; }
        public bool? BluetoothBlocked { get; set; }
        public bool? CameraBlocked { get; set; }
        public bool? CellularBlockDataRoaming { get; set; }
        public bool? CellularBlockMessaging { get; set; }
        public bool? CellularBlockVoiceRoaming { get; set; }
        public bool? CellularBlockWiFiTethering { get; set; }
        public AppListItem[]? CompliantAppsList { get; set; }
        public AppListType? CompliantAppListType { get; set; }
        public bool? DiagnosticDataBlockSubmission { get; set; }
        public bool? LocationServicesBlocked { get; set; }
        public bool? GoogleAccountBlockAutoSync { get; set; }
        public bool? GooglePlayStoreBlocked { get; set; }
        public bool? KioskModeBlockSleepButton { get; set; }
        public bool? KioskModeBlockVolumeButtons { get; set; }
        public AppListItem[]? KioskModeApps { get; set; }
        public bool? NfcBlocked { get; set; }
        public bool? PasswordBlockFingerprintUnlock { get; set; }
        public bool? PasswordBlockTrustAgents { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
        public AndroidRequiredPasswordType? PasswordRequiredType { get; set; }
        public bool? PasswordRequired { get; set; }
        public bool? PowerOffBlocked { get; set; }
        public bool? FactoryResetBlocked { get; set; }
        public bool? ScreenCaptureBlocked { get; set; }
        public bool? DeviceSharingAllowed { get; set; }
        public bool? StorageBlockGoogleBackup { get; set; }
        public bool? StorageBlockRemovableStorage { get; set; }
        public bool? StorageRequireDeviceEncryption { get; set; }
        public bool? StorageRequireRemovableStorageEncryption { get; set; }
        public bool? VoiceAssistantBlocked { get; set; }
        public bool? VoiceDialingBlocked { get; set; }
        public bool? WebBrowserBlockPopups { get; set; }
        public bool? WebBrowserBlockAutofill { get; set; }
        public bool? WebBrowserBlockJavaScript { get; set; }
        public bool? WebBrowserBlocked { get; set; }
        public WebBrowserCookieSettings? WebBrowserCookieSettings { get; set; }
        public bool? WiFiBlocked { get; set; }
        public AppListItem[]? AppsInstallAllowList { get; set; }
        public AppListItem[]? AppsLaunchBlockList { get; set; }
        public AppListItem[]? AppsHideList { get; set; }
        public bool? SecurityRequireVerifyApps { get; set; }
    }
}
