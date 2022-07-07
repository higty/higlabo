using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamAndroidmanagedappprotectionCreateParameter : IRestApiParameter
    {
        public enum IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppDataTransferLevel
        {
            AllApps,
            ManagedApps,
            None,
        }
        public enum IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppClipboardSharingLevel
        {
            AllApps,
            ManagedAppsWithPasteIn,
            ManagedApps,
            Blocked,
        }
        public enum IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppPinCharacterSet
        {
            Numeric,
            AlphanumericAndSymbol,
        }
        public enum IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppDataStorageLocation
        {
            OneDriveForBusiness,
            SharePoint,
            Box,
            LocalStorage,
        }
        public enum IntuneMamAndroidmanagedappprotectionCreateParameterManagedBrowserType
        {
            NotConfigured,
            MicrosoftEdge,
        }
        public enum ApiPath
        {
            DeviceAppManagement_AndroidManagedAppProtections,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_AndroidManagedAppProtections: return $"/deviceAppManagement/androidManagedAppProtections";
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
        public string? PeriodOfflineBeforeAccessCheck { get; set; }
        public string? PeriodOnlineBeforeAccessCheck { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppDataTransferLevel AllowedInboundDataTransferSources { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppDataTransferLevel AllowedOutboundDataTransferDestinations { get; set; }
        public bool? OrganizationalCredentialsRequired { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppClipboardSharingLevel AllowedOutboundClipboardSharingLevel { get; set; }
        public bool? DataBackupBlocked { get; set; }
        public bool? DeviceComplianceRequired { get; set; }
        public bool? ManagedBrowserToOpenLinksRequired { get; set; }
        public bool? SaveAsBlocked { get; set; }
        public string? PeriodOfflineBeforeWipeIsEnforced { get; set; }
        public bool? PinRequired { get; set; }
        public Int32? MaximumPinRetries { get; set; }
        public bool? SimplePinBlocked { get; set; }
        public Int32? MinimumPinLength { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppPinCharacterSet PinCharacterSet { get; set; }
        public string? PeriodBeforePinReset { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedAppDataStorageLocation AllowedDataStorageLocations { get; set; }
        public bool? ContactSyncBlocked { get; set; }
        public bool? PrintBlocked { get; set; }
        public bool? FingerprintBlocked { get; set; }
        public bool? DisableAppPinIfDevicePinIsSet { get; set; }
        public string? MinimumRequiredOsVersion { get; set; }
        public string? MinimumWarningOsVersion { get; set; }
        public string? MinimumRequiredAppVersion { get; set; }
        public string? MinimumWarningAppVersion { get; set; }
        public IntuneMamAndroidmanagedappprotectionCreateParameterManagedBrowserType ManagedBrowser { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? ScreenCaptureBlocked { get; set; }
        public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
        public bool? EncryptAppData { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public string? MinimumRequiredPatchVersion { get; set; }
        public string? MinimumWarningPatchVersion { get; set; }
        public string? CustomBrowserPackageId { get; set; }
        public string? CustomBrowserDisplayName { get; set; }
    }
    public partial class IntuneMamAndroidmanagedappprotectionCreateResponse : RestApiResponse
    {
        public enum AndroidManagedAppProtectionManagedAppDataTransferLevel
        {
            AllApps,
            ManagedApps,
            None,
        }
        public enum AndroidManagedAppProtectionManagedAppClipboardSharingLevel
        {
            AllApps,
            ManagedAppsWithPasteIn,
            ManagedApps,
            Blocked,
        }
        public enum AndroidManagedAppProtectionManagedAppPinCharacterSet
        {
            Numeric,
            AlphanumericAndSymbol,
        }
        public enum AndroidManagedAppProtectionManagedBrowserType
        {
            NotConfigured,
            MicrosoftEdge,
        }

        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Version { get; set; }
        public string? PeriodOfflineBeforeAccessCheck { get; set; }
        public string? PeriodOnlineBeforeAccessCheck { get; set; }
        public ManagedAppDataTransferLevel? AllowedInboundDataTransferSources { get; set; }
        public ManagedAppDataTransferLevel? AllowedOutboundDataTransferDestinations { get; set; }
        public bool? OrganizationalCredentialsRequired { get; set; }
        public ManagedAppClipboardSharingLevel? AllowedOutboundClipboardSharingLevel { get; set; }
        public bool? DataBackupBlocked { get; set; }
        public bool? DeviceComplianceRequired { get; set; }
        public bool? ManagedBrowserToOpenLinksRequired { get; set; }
        public bool? SaveAsBlocked { get; set; }
        public string? PeriodOfflineBeforeWipeIsEnforced { get; set; }
        public bool? PinRequired { get; set; }
        public Int32? MaximumPinRetries { get; set; }
        public bool? SimplePinBlocked { get; set; }
        public Int32? MinimumPinLength { get; set; }
        public ManagedAppPinCharacterSet? PinCharacterSet { get; set; }
        public string? PeriodBeforePinReset { get; set; }
        public ManagedAppDataStorageLocation[]? AllowedDataStorageLocations { get; set; }
        public bool? ContactSyncBlocked { get; set; }
        public bool? PrintBlocked { get; set; }
        public bool? FingerprintBlocked { get; set; }
        public bool? DisableAppPinIfDevicePinIsSet { get; set; }
        public string? MinimumRequiredOsVersion { get; set; }
        public string? MinimumWarningOsVersion { get; set; }
        public string? MinimumRequiredAppVersion { get; set; }
        public string? MinimumWarningAppVersion { get; set; }
        public ManagedBrowserType? ManagedBrowser { get; set; }
        public bool? IsAssigned { get; set; }
        public bool? ScreenCaptureBlocked { get; set; }
        public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
        public bool? EncryptAppData { get; set; }
        public Int32? DeployedAppCount { get; set; }
        public string? MinimumRequiredPatchVersion { get; set; }
        public string? MinimumWarningPatchVersion { get; set; }
        public string? CustomBrowserPackageId { get; set; }
        public string? CustomBrowserDisplayName { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionCreateResponse> IntuneMamAndroidmanagedappprotectionCreateAsync()
        {
            var p = new IntuneMamAndroidmanagedappprotectionCreateParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionCreateParameter, IntuneMamAndroidmanagedappprotectionCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionCreateResponse> IntuneMamAndroidmanagedappprotectionCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamAndroidmanagedappprotectionCreateParameter();
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionCreateParameter, IntuneMamAndroidmanagedappprotectionCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionCreateResponse> IntuneMamAndroidmanagedappprotectionCreateAsync(IntuneMamAndroidmanagedappprotectionCreateParameter parameter)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionCreateParameter, IntuneMamAndroidmanagedappprotectionCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-androidmanagedappprotection-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamAndroidmanagedappprotectionCreateResponse> IntuneMamAndroidmanagedappprotectionCreateAsync(IntuneMamAndroidmanagedappprotectionCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamAndroidmanagedappprotectionCreateParameter, IntuneMamAndroidmanagedappprotectionCreateResponse>(parameter, cancellationToken);
        }
    }
}
