using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10generalconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceConfigurations: return $"/deviceManagement/deviceConfigurations";
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
    }
    public partial class IntuneDeviceconfigWindows10generalconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10generalconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows10GeneralConfiguration
        {
            public enum Windows10GeneralConfigurationDiagnosticDataSubmissionMode
            {
                UserDefined,
                None,
                Basic,
                Enhanced,
                Full,
            }
            public enum Windows10GeneralConfigurationEdgeCookiePolicy
            {
                UserDefined,
                Allow,
                BlockThirdParty,
                BlockAll,
            }
            public enum Windows10GeneralConfigurationDefenderMonitorFileActivity
            {
                UserDefined,
                Disable,
                MonitorAllFiles,
                MonitorIncomingFilesOnly,
                MonitorOutgoingFilesOnly,
            }
            public enum Windows10GeneralConfigurationDefenderCloudBlockLevelType
            {
                NotConfigured,
                High,
                HighPlus,
                ZeroTolerance,
            }
            public enum Windows10GeneralConfigurationDefenderPromptForSampleSubmission
            {
                UserDefined,
                AlwaysPrompt,
                PromptBeforeSendingPersonalData,
                NeverSendData,
                SendAllDataWithoutPrompting,
            }
            public enum Windows10GeneralConfigurationDefenderScanType
            {
                UserDefined,
                Disabled,
                Quick,
                Full,
            }
            public enum Windows10GeneralConfigurationWeeklySchedule
            {
                UserDefined,
                Everyday,
                Sunday,
                Monday,
                Tuesday,
                Wednesday,
                Thursday,
                Friday,
                Saturday,
            }
            public enum Windows10GeneralConfigurationRequiredPasswordType
            {
                DeviceDefault,
                Alphanumeric,
                Numeric,
            }
            public enum Windows10GeneralConfigurationStateManagementSetting
            {
                NotConfigured,
                Blocked,
                Allowed,
            }
            public enum Windows10GeneralConfigurationWindowsStartMenuAppListVisibilityType
            {
                UserDefined,
                Collapse,
                Remove,
                DisableSettingsApp,
            }
            public enum Windows10GeneralConfigurationWindowsStartMenuModeType
            {
                UserDefined,
                FullScreen,
                NonFullScreen,
            }
            public enum Windows10GeneralConfigurationVisibilitySetting
            {
                NotConfigured,
                Hide,
                Show,
            }
            public enum Windows10GeneralConfigurationWindowsSpotlightEnablementSettings
            {
                NotConfigured,
                Disabled,
                Enabled,
            }
            public enum Windows10GeneralConfigurationSafeSearchFilterType
            {
                UserDefined,
                Strict,
                Moderate,
            }

            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public string? EnterpriseCloudPrintDiscoveryEndPoint { get; set; }
            public string? EnterpriseCloudPrintOAuthAuthority { get; set; }
            public string? EnterpriseCloudPrintOAuthClientIdentifier { get; set; }
            public string? EnterpriseCloudPrintResourceIdentifier { get; set; }
            public Int32? EnterpriseCloudPrintDiscoveryMaxLimit { get; set; }
            public string? EnterpriseCloudPrintMopriaDiscoveryResourceIdentifier { get; set; }
            public bool? SearchBlockDiacritics { get; set; }
            public bool? SearchDisableAutoLanguageDetection { get; set; }
            public bool? SearchDisableIndexingEncryptedItems { get; set; }
            public bool? SearchEnableRemoteQueries { get; set; }
            public bool? SearchDisableIndexerBackoff { get; set; }
            public bool? SearchDisableIndexingRemovableDrive { get; set; }
            public bool? SearchEnableAutomaticIndexSizeManangement { get; set; }
            public DiagnosticDataSubmissionMode? DiagnosticsDataSubmissionMode { get; set; }
            public bool? OneDriveDisableFileSync { get; set; }
            public bool? SmartScreenEnableAppInstallControl { get; set; }
            public string? PersonalizationDesktopImageUrl { get; set; }
            public string? PersonalizationLockScreenImageUrl { get; set; }
            public String[]? BluetoothAllowedServices { get; set; }
            public bool? BluetoothBlockAdvertising { get; set; }
            public bool? BluetoothBlockDiscoverableMode { get; set; }
            public bool? BluetoothBlockPrePairing { get; set; }
            public bool? EdgeBlockAutofill { get; set; }
            public bool? EdgeBlocked { get; set; }
            public EdgeCookiePolicy? EdgeCookiePolicy { get; set; }
            public bool? EdgeBlockDeveloperTools { get; set; }
            public bool? EdgeBlockSendingDoNotTrackHeader { get; set; }
            public bool? EdgeBlockExtensions { get; set; }
            public bool? EdgeBlockInPrivateBrowsing { get; set; }
            public bool? EdgeBlockJavaScript { get; set; }
            public bool? EdgeBlockPasswordManager { get; set; }
            public bool? EdgeBlockAddressBarDropdown { get; set; }
            public bool? EdgeBlockCompatibilityList { get; set; }
            public bool? EdgeClearBrowsingDataOnExit { get; set; }
            public bool? EdgeAllowStartPagesModification { get; set; }
            public bool? EdgeDisableFirstRunPage { get; set; }
            public bool? EdgeBlockLiveTileDataCollection { get; set; }
            public bool? EdgeSyncFavoritesWithInternetExplorer { get; set; }
            public bool? CellularBlockDataWhenRoaming { get; set; }
            public bool? CellularBlockVpn { get; set; }
            public bool? CellularBlockVpnWhenRoaming { get; set; }
            public bool? DefenderRequireRealTimeMonitoring { get; set; }
            public bool? DefenderRequireBehaviorMonitoring { get; set; }
            public bool? DefenderRequireNetworkInspectionSystem { get; set; }
            public bool? DefenderScanDownloads { get; set; }
            public bool? DefenderScanScriptsLoadedInInternetExplorer { get; set; }
            public bool? DefenderBlockEndUserAccess { get; set; }
            public Int32? DefenderSignatureUpdateIntervalInHours { get; set; }
            public DefenderMonitorFileActivity? DefenderMonitorFileActivity { get; set; }
            public Int32? DefenderDaysBeforeDeletingQuarantinedMalware { get; set; }
            public Int32? DefenderScanMaxCpu { get; set; }
            public bool? DefenderScanArchiveFiles { get; set; }
            public bool? DefenderScanIncomingMail { get; set; }
            public bool? DefenderScanRemovableDrivesDuringFullScan { get; set; }
            public bool? DefenderScanMappedNetworkDrivesDuringFullScan { get; set; }
            public bool? DefenderScanNetworkFiles { get; set; }
            public bool? DefenderRequireCloudProtection { get; set; }
            public DefenderCloudBlockLevelType? DefenderCloudBlockLevel { get; set; }
            public DefenderPromptForSampleSubmission? DefenderPromptForSampleSubmission { get; set; }
            public TimeOnly? DefenderScheduledQuickScanTime { get; set; }
            public DefenderScanType? DefenderScanType { get; set; }
            public WeeklySchedule? DefenderSystemScanSchedule { get; set; }
            public TimeOnly? DefenderScheduledScanTime { get; set; }
            public DefenderDetectedMalwareActions? DefenderDetectedMalwareActions { get; set; }
            public String[]? DefenderFileExtensionsToExclude { get; set; }
            public String[]? DefenderFilesAndFoldersToExclude { get; set; }
            public String[]? DefenderProcessesToExclude { get; set; }
            public bool? LockScreenAllowTimeoutConfiguration { get; set; }
            public bool? LockScreenBlockActionCenterNotifications { get; set; }
            public bool? LockScreenBlockCortana { get; set; }
            public bool? LockScreenBlockToastNotifications { get; set; }
            public Int32? LockScreenTimeoutInSeconds { get; set; }
            public bool? PasswordBlockSimple { get; set; }
            public Int32? PasswordExpirationDays { get; set; }
            public Int32? PasswordMinimumLength { get; set; }
            public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
            public Int32? PasswordMinimumCharacterSetCount { get; set; }
            public Int32? PasswordPreviousPasswordBlockCount { get; set; }
            public bool? PasswordRequired { get; set; }
            public bool? PasswordRequireWhenResumeFromIdleState { get; set; }
            public RequiredPasswordType? PasswordRequiredType { get; set; }
            public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
            public StateManagementSetting? PrivacyAdvertisingId { get; set; }
            public bool? PrivacyAutoAcceptPairingAndConsentPrompts { get; set; }
            public bool? PrivacyBlockInputPersonalization { get; set; }
            public bool? StartBlockUnpinningAppsFromTaskbar { get; set; }
            public WindowsStartMenuAppListVisibilityType? StartMenuAppListVisibility { get; set; }
            public bool? StartMenuHideChangeAccountSettings { get; set; }
            public bool? StartMenuHideFrequentlyUsedApps { get; set; }
            public bool? StartMenuHideHibernate { get; set; }
            public bool? StartMenuHideLock { get; set; }
            public bool? StartMenuHidePowerButton { get; set; }
            public bool? StartMenuHideRecentJumpLists { get; set; }
            public bool? StartMenuHideRecentlyAddedApps { get; set; }
            public bool? StartMenuHideRestartOptions { get; set; }
            public bool? StartMenuHideShutDown { get; set; }
            public bool? StartMenuHideSignOut { get; set; }
            public bool? StartMenuHideSleep { get; set; }
            public bool? StartMenuHideSwitchAccount { get; set; }
            public bool? StartMenuHideUserTile { get; set; }
            public string? StartMenuLayoutEdgeAssetsXml { get; set; }
            public string? StartMenuLayoutXml { get; set; }
            public WindowsStartMenuModeType? StartMenuMode { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderDocuments { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderDownloads { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderFileExplorer { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderHomeGroup { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderMusic { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderNetwork { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderPersonalFolder { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderPictures { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderSettings { get; set; }
            public VisibilitySetting? StartMenuPinnedFolderVideos { get; set; }
            public bool? SettingsBlockSettingsApp { get; set; }
            public bool? SettingsBlockSystemPage { get; set; }
            public bool? SettingsBlockDevicesPage { get; set; }
            public bool? SettingsBlockNetworkInternetPage { get; set; }
            public bool? SettingsBlockPersonalizationPage { get; set; }
            public bool? SettingsBlockAccountsPage { get; set; }
            public bool? SettingsBlockTimeLanguagePage { get; set; }
            public bool? SettingsBlockEaseOfAccessPage { get; set; }
            public bool? SettingsBlockPrivacyPage { get; set; }
            public bool? SettingsBlockUpdateSecurityPage { get; set; }
            public bool? SettingsBlockAppsPage { get; set; }
            public bool? SettingsBlockGamingPage { get; set; }
            public bool? WindowsSpotlightBlockConsumerSpecificFeatures { get; set; }
            public bool? WindowsSpotlightBlocked { get; set; }
            public bool? WindowsSpotlightBlockOnActionCenter { get; set; }
            public bool? WindowsSpotlightBlockTailoredExperiences { get; set; }
            public bool? WindowsSpotlightBlockThirdPartyNotifications { get; set; }
            public bool? WindowsSpotlightBlockWelcomeExperience { get; set; }
            public bool? WindowsSpotlightBlockWindowsTips { get; set; }
            public WindowsSpotlightEnablementSettings? WindowsSpotlightConfigureOnLockScreen { get; set; }
            public bool? NetworkProxyApplySettingsDeviceWide { get; set; }
            public bool? NetworkProxyDisableAutoDetect { get; set; }
            public string? NetworkProxyAutomaticConfigurationUrl { get; set; }
            public Windows10NetworkProxyServer? NetworkProxyServer { get; set; }
            public bool? AccountsBlockAddingNonMicrosoftAccountEmail { get; set; }
            public bool? AntiTheftModeBlocked { get; set; }
            public bool? BluetoothBlocked { get; set; }
            public bool? CameraBlocked { get; set; }
            public bool? ConnectedDevicesServiceBlocked { get; set; }
            public bool? CertificatesBlockManualRootCertificateInstallation { get; set; }
            public bool? CopyPasteBlocked { get; set; }
            public bool? CortanaBlocked { get; set; }
            public bool? DeviceManagementBlockFactoryResetOnMobile { get; set; }
            public bool? DeviceManagementBlockManualUnenroll { get; set; }
            public SafeSearchFilterType? SafeSearchFilter { get; set; }
            public bool? EdgeBlockPopups { get; set; }
            public bool? EdgeBlockSearchSuggestions { get; set; }
            public bool? EdgeBlockSendingIntranetTrafficToInternetExplorer { get; set; }
            public bool? EdgeSendIntranetTrafficToInternetExplorer { get; set; }
            public bool? EdgeRequireSmartScreen { get; set; }
            public string? EdgeEnterpriseModeSiteListLocation { get; set; }
            public string? EdgeFirstRunUrl { get; set; }
            public EdgeSearchEngineBase? EdgeSearchEngine { get; set; }
            public String[]? EdgeHomepageUrls { get; set; }
            public bool? EdgeBlockAccessToAboutFlags { get; set; }
            public bool? SmartScreenBlockPromptOverride { get; set; }
            public bool? SmartScreenBlockPromptOverrideForFiles { get; set; }
            public bool? WebRtcBlockLocalhostIpAddress { get; set; }
            public bool? InternetSharingBlocked { get; set; }
            public bool? SettingsBlockAddProvisioningPackage { get; set; }
            public bool? SettingsBlockRemoveProvisioningPackage { get; set; }
            public bool? SettingsBlockChangeSystemTime { get; set; }
            public bool? SettingsBlockEditDeviceName { get; set; }
            public bool? SettingsBlockChangeRegion { get; set; }
            public bool? SettingsBlockChangeLanguage { get; set; }
            public bool? SettingsBlockChangePowerSleep { get; set; }
            public bool? LocationServicesBlocked { get; set; }
            public bool? MicrosoftAccountBlocked { get; set; }
            public bool? MicrosoftAccountBlockSettingsSync { get; set; }
            public bool? NfcBlocked { get; set; }
            public bool? ResetProtectionModeBlocked { get; set; }
            public bool? ScreenCaptureBlocked { get; set; }
            public bool? StorageBlockRemovableStorage { get; set; }
            public bool? StorageRequireMobileDeviceEncryption { get; set; }
            public bool? UsbBlocked { get; set; }
            public bool? VoiceRecordingBlocked { get; set; }
            public bool? WiFiBlockAutomaticConnectHotspots { get; set; }
            public bool? WiFiBlocked { get; set; }
            public bool? WiFiBlockManualConfiguration { get; set; }
            public Int32? WiFiScanInterval { get; set; }
            public bool? WirelessDisplayBlockProjectionToThisDevice { get; set; }
            public bool? WirelessDisplayBlockUserInputFromReceiver { get; set; }
            public bool? WirelessDisplayRequirePinForPairing { get; set; }
            public bool? WindowsStoreBlocked { get; set; }
            public StateManagementSetting? AppsAllowTrustedAppsSideloading { get; set; }
            public bool? WindowsStoreBlockAutoUpdate { get; set; }
            public StateManagementSetting? DeveloperUnlockSetting { get; set; }
            public bool? SharedUserAppDataAllowed { get; set; }
            public bool? AppsBlockWindowsStoreOriginatedApps { get; set; }
            public bool? WindowsStoreEnablePrivateStoreOnly { get; set; }
            public bool? StorageRestrictAppDataToSystemVolume { get; set; }
            public bool? StorageRestrictAppInstallToSystemVolume { get; set; }
            public bool? GameDvrBlocked { get; set; }
            public bool? ExperienceBlockDeviceDiscovery { get; set; }
            public bool? ExperienceBlockErrorDialogWhenNoSIM { get; set; }
            public bool? ExperienceBlockTaskSwitcher { get; set; }
            public bool? LogonBlockFastUserSwitching { get; set; }
            public bool? TenantLockdownRequireNetworkDuringOutOfBoxExperience { get; set; }
        }

        public Windows10GeneralConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationListResponse> IntuneDeviceconfigWindows10generalconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows10generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationListParameter, IntuneDeviceconfigWindows10generalconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationListResponse> IntuneDeviceconfigWindows10generalconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationListParameter, IntuneDeviceconfigWindows10generalconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationListResponse> IntuneDeviceconfigWindows10generalconfigurationListAsync(IntuneDeviceconfigWindows10generalconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationListParameter, IntuneDeviceconfigWindows10generalconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10generalconfigurationListResponse> IntuneDeviceconfigWindows10generalconfigurationListAsync(IntuneDeviceconfigWindows10generalconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10generalconfigurationListParameter, IntuneDeviceconfigWindows10generalconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
