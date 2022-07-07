using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneMamManagedappprotectionListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement_ManagedAppPolicies,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies,
            DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement_ManagedAppPolicies: return $"/deviceAppManagement/managedAppPolicies";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_AppliedPolicies: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/appliedPolicies";
                    case ApiPath.DeviceAppManagement_ManagedAppRegistrations_ManagedAppRegistrationId_IntendedPolicies: return $"/deviceAppManagement/managedAppRegistrations/{ManagedAppRegistrationId}/intendedPolicies";
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
        public string ManagedAppRegistrationId { get; set; }
    }
    public partial class IntuneMamManagedappprotectionListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-managedappprotection?view=graph-rest-1.0
        /// </summary>
        public partial class ManagedAppProtection
        {
            public enum ManagedAppProtectionManagedAppDataTransferLevel
            {
                AllApps,
                ManagedApps,
                None,
            }
            public enum ManagedAppProtectionManagedAppClipboardSharingLevel
            {
                AllApps,
                ManagedAppsWithPasteIn,
                ManagedApps,
                Blocked,
            }
            public enum ManagedAppProtectionManagedAppPinCharacterSet
            {
                Numeric,
                AlphanumericAndSymbol,
            }
            public enum ManagedAppProtectionManagedBrowserType
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
        }

        public ManagedAppProtection[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionListResponse> IntuneMamManagedappprotectionListAsync()
        {
            var p = new IntuneMamManagedappprotectionListParameter();
            return await this.SendAsync<IntuneMamManagedappprotectionListParameter, IntuneMamManagedappprotectionListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionListResponse> IntuneMamManagedappprotectionListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneMamManagedappprotectionListParameter();
            return await this.SendAsync<IntuneMamManagedappprotectionListParameter, IntuneMamManagedappprotectionListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionListResponse> IntuneMamManagedappprotectionListAsync(IntuneMamManagedappprotectionListParameter parameter)
        {
            return await this.SendAsync<IntuneMamManagedappprotectionListParameter, IntuneMamManagedappprotectionListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-mam-managedappprotection-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneMamManagedappprotectionListResponse> IntuneMamManagedappprotectionListAsync(IntuneMamManagedappprotectionListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneMamManagedappprotectionListParameter, IntuneMamManagedappprotectionListResponse>(parameter, cancellationToken);
        }
    }
}
