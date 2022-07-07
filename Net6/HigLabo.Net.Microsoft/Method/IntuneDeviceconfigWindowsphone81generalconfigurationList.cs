using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windowsphone81generalconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class WindowsPhone81GeneralConfiguration
        {
            public enum WindowsPhone81GeneralConfigurationAppListType
            {
                None,
                AppsInListCompliant,
                AppsNotInListCompliant,
            }
            public enum WindowsPhone81GeneralConfigurationRequiredPasswordType
            {
                DeviceDefault,
                Alphanumeric,
                Numeric,
            }

            public string? Id { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public Int32? Version { get; set; }
            public bool? ApplyOnlyToWindowsPhone81 { get; set; }
            public bool? AppsBlockCopyPaste { get; set; }
            public bool? BluetoothBlocked { get; set; }
            public bool? CameraBlocked { get; set; }
            public bool? CellularBlockWifiTethering { get; set; }
            public AppListItem[]? CompliantAppsList { get; set; }
            public AppListType? CompliantAppListType { get; set; }
            public bool? DiagnosticDataBlockSubmission { get; set; }
            public bool? EmailBlockAddingAccounts { get; set; }
            public bool? LocationServicesBlocked { get; set; }
            public bool? MicrosoftAccountBlocked { get; set; }
            public bool? NfcBlocked { get; set; }
            public bool? PasswordBlockSimple { get; set; }
            public Int32? PasswordExpirationDays { get; set; }
            public Int32? PasswordMinimumLength { get; set; }
            public Int32? PasswordMinutesOfInactivityBeforeScreenTimeout { get; set; }
            public Int32? PasswordMinimumCharacterSetCount { get; set; }
            public Int32? PasswordPreviousPasswordBlockCount { get; set; }
            public Int32? PasswordSignInFailureCountBeforeFactoryReset { get; set; }
            public RequiredPasswordType? PasswordRequiredType { get; set; }
            public bool? PasswordRequired { get; set; }
            public bool? ScreenCaptureBlocked { get; set; }
            public bool? StorageBlockRemovableStorage { get; set; }
            public bool? StorageRequireEncryption { get; set; }
            public bool? WebBrowserBlocked { get; set; }
            public bool? WifiBlocked { get; set; }
            public bool? WifiBlockAutomaticConnectHotspots { get; set; }
            public bool? WifiBlockHotspotReporting { get; set; }
            public bool? WindowsStoreBlocked { get; set; }
        }

        public WindowsPhone81GeneralConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationListResponse> IntuneDeviceconfigWindowsphone81generalconfigurationListAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationListParameter, IntuneDeviceconfigWindowsphone81generalconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationListResponse> IntuneDeviceconfigWindowsphone81generalconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationListParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationListParameter, IntuneDeviceconfigWindowsphone81generalconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationListResponse> IntuneDeviceconfigWindowsphone81generalconfigurationListAsync(IntuneDeviceconfigWindowsphone81generalconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationListParameter, IntuneDeviceconfigWindowsphone81generalconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationListResponse> IntuneDeviceconfigWindowsphone81generalconfigurationListAsync(IntuneDeviceconfigWindowsphone81generalconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationListParameter, IntuneDeviceconfigWindowsphone81generalconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
