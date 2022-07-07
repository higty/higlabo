using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamDefaultmanagedappprotectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_DefaultManagedAppProtections,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_DefaultManagedAppProtections: return $"/deviceAppManagement/defaultManagedAppProtections";
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
    public partial class IntuneMamDefaultmanagedappprotectionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-defaultmanagedappprotection?view=graph-rest-1.0
        /// </summary>
        public partial class DefaultManagedAppProtection
        {
            public enum DefaultManagedAppProtectionManagedAppDataTransferLevel
            {
                AllApps,
                ManagedApps,
                None,
            }
            public enum DefaultManagedAppProtectionManagedAppClipboardSharingLevel
            {
                AllApps,
                ManagedAppsWithPasteIn,
                ManagedApps,
                Blocked,
            }
            public enum DefaultManagedAppProtectionManagedAppPinCharacterSet
            {
                Numeric,
                AlphanumericAndSymbol,
            }
            public enum DefaultManagedAppProtectionManagedBrowserType
            {
                NotConfigured,
                MicrosoftEdge,
            }
            public enum DefaultManagedAppProtectionManagedAppDataEncryptionType
            {
                UseDeviceSettings,
                AfterDeviceRestart,
                WhenDeviceLockedExceptOpenFiles,
                WhenDeviceLocked,
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
            public ManagedAppDataEncryptionType? AppDataEncryptionType { get; set; }
            public bool? ScreenCaptureBlocked { get; set; }
            public bool? EncryptAppData { get; set; }
            public bool? DisableAppEncryptionIfDeviceEncryptionIsEnabled { get; set; }
            public string? MinimumRequiredSdkVersion { get; set; }
            public KeyValuePair[]? CustomSettings { get; set; }
            public Int32? DeployedAppCount { get; set; }
            public string? MinimumRequiredPatchVersion { get; set; }
            public string? MinimumWarningPatchVersion { get; set; }
            public bool? FaceIdBlocked { get; set; }
        }

        public DefaultManagedAppProtection[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionListResponse> IntuneMamDefaultmanagedappprotectionListAsync()
        {
            var p = new IntuneMamDefaultmanagedappprotectionListParameter();
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionListParameter, IntuneMamDefaultmanagedappprotectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionListResponse> IntuneMamDefaultmanagedappprotectionListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamDefaultmanagedappprotectionListParameter();
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionListParameter, IntuneMamDefaultmanagedappprotectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionListResponse> IntuneMamDefaultmanagedappprotectionListAsync(IntuneMamDefaultmanagedappprotectionListParameter parameter)
        {
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionListParameter, IntuneMamDefaultmanagedappprotectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-defaultmanagedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamDefaultmanagedappprotectionListResponse> IntuneMamDefaultmanagedappprotectionListAsync(IntuneMamDefaultmanagedappprotectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamDefaultmanagedappprotectionListParameter, IntuneMamDefaultmanagedappprotectionListResponse>(parameter, cancellationToken);
        }
    }
}
