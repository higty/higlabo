using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows81generalconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindows81generalconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows81generalconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class Windows81GeneralConfiguration
        {
            public enum Windows81GeneralConfigurationInternetSiteSecurityLevel
            {
                UserDefined,
                Medium,
                MediumHigh,
                High,
            }
            public enum Windows81GeneralConfigurationSiteSecurityLevel
            {
                UserDefined,
                Low,
                MediumLow,
                Medium,
                MediumHigh,
                High,
            }
            public enum Windows81GeneralConfigurationRequiredPasswordType
            {
                DeviceDefault,
                Alphanumeric,
                Numeric,
            }
            public enum Windows81GeneralConfigurationWindowsUserAccountControlSettings
            {
                UserDefined,
                AlwaysNotify,
                NotifyOnAppChanges,
                NotifyOnAppChangesWithoutDimming,
                NeverNotify,
            }

            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public bool? AccountsBlockAddingNonMicrosoftAccountEmail { get; set; }
            public bool? ApplyOnlyToWindows81 { get; set; }
            public bool? BrowserBlockAutofill { get; set; }
            public bool? BrowserBlockAutomaticDetectionOfIntranetSites { get; set; }
            public bool? BrowserBlockEnterpriseModeAccess { get; set; }
            public bool? BrowserBlockJavaScript { get; set; }
            public bool? BrowserBlockPlugins { get; set; }
            public bool? BrowserBlockPopups { get; set; }
            public bool? BrowserBlockSendingDoNotTrackHeader { get; set; }
            public bool? BrowserBlockSingleWordEntryOnIntranetSites { get; set; }
            public bool? BrowserRequireSmartScreen { get; set; }
            public string? BrowserEnterpriseModeSiteListLocation { get; set; }
            public InternetSiteSecurityLevel? BrowserInternetSecurityLevel { get; set; }
            public SiteSecurityLevel? BrowserIntranetSecurityLevel { get; set; }
            public string? BrowserLoggingReportLocation { get; set; }
            public bool? BrowserRequireHighSecurityForRestrictedSites { get; set; }
            public bool? BrowserRequireFirewall { get; set; }
            public bool? BrowserRequireFraudWarning { get; set; }
            public SiteSecurityLevel? BrowserTrustedSitesSecurityLevel { get; set; }
            public bool? CellularBlockDataRoaming { get; set; }
            public bool? DiagnosticsBlockDataSubmission { get; set; }
            public bool? PasswordBlockPicturePasswordAndPin { get; set; }
            public Int32? PasswordExpirationDays { get; set; }
            public Int32? PasswordMinimumLength { get; set; }
            public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
            public Int32? PasswordMinimumCharacterSetCount { get; set; }
            public Int32? PasswordPreviousPasswordBlockCount { get; set; }
            public RequiredPasswordType? PasswordRequiredType { get; set; }
            public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
            public bool? StorageRequireDeviceEncryption { get; set; }
            public bool? UpdatesRequireAutomaticUpdates { get; set; }
            public WindowsUserAccountControlSettings? UserAccountControlSettings { get; set; }
            public string? WorkFoldersUrl { get; set; }
        }

        public Windows81GeneralConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81generalconfigurationListResponse> IntuneDeviceconfigWindows81generalconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindows81generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81generalconfigurationListParameter, IntuneDeviceconfigWindows81generalconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81generalconfigurationListResponse> IntuneDeviceconfigWindows81generalconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows81generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows81generalconfigurationListParameter, IntuneDeviceconfigWindows81generalconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81generalconfigurationListResponse> IntuneDeviceconfigWindows81generalconfigurationListAsync(IntuneDeviceconfigWindows81generalconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81generalconfigurationListParameter, IntuneDeviceconfigWindows81generalconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows81generalconfigurationListResponse> IntuneDeviceconfigWindows81generalconfigurationListAsync(IntuneDeviceconfigWindows81generalconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows81generalconfigurationListParameter, IntuneDeviceconfigWindows81generalconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
