using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows81generalconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class Windows81GeneralConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool AccountsBlockAddingNonMicrosoftAccountEmail { get; set; }
        public bool ApplyOnlyToWindows81 { get; set; }
        public bool BrowserBlockAutofill { get; set; }
        public bool BrowserBlockAutomaticDetectionOfIntranetSites { get; set; }
        public bool BrowserBlockEnterpriseModeAccess { get; set; }
        public bool BrowserBlockJavaScript { get; set; }
        public bool BrowserBlockPlugins { get; set; }
        public bool BrowserBlockPopups { get; set; }
        public bool BrowserBlockSendingDoNotTrackHeader { get; set; }
        public bool BrowserBlockSingleWordEntryOnIntranetSites { get; set; }
        public bool BrowserRequireSmartScreen { get; set; }
        public string BrowserEnterpriseModeSiteListLocation { get; set; }
        public Windows81GeneralConfigurationInternetSiteSecurityLevel BrowserInternetSecurityLevel { get; set; }
        public Windows81GeneralConfigurationSiteSecurityLevel BrowserIntranetSecurityLevel { get; set; }
        public string BrowserLoggingReportLocation { get; set; }
        public bool BrowserRequireHighSecurityForRestrictedSites { get; set; }
        public bool BrowserRequireFirewall { get; set; }
        public bool BrowserRequireFraudWarning { get; set; }
        public Windows81GeneralConfigurationSiteSecurityLevel BrowserTrustedSitesSecurityLevel { get; set; }
        public bool CellularBlockDataRoaming { get; set; }
        public bool DiagnosticsBlockDataSubmission { get; set; }
        public bool PasswordBlockPicturePasswordAndPin { get; set; }
        public Int32? PasswordExpirationDays { get; set; }
        public Int32? PasswordMinimumLength { get; set; }
        public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
        public Int32? PasswordMinimumCharacterSetCount { get; set; }
        public Int32? PasswordPreviousPasswordBlockCount { get; set; }
        public Windows81GeneralConfigurationRequiredPasswordType PasswordRequiredType { get; set; }
        public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
        public bool StorageRequireDeviceEncryption { get; set; }
        public bool UpdatesRequireAutomaticUpdates { get; set; }
        public Windows81GeneralConfigurationWindowsUserAccountControlSettings UserAccountControlSettings { get; set; }
        public string WorkFoldersUrl { get; set; }
    }
}
