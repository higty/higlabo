using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameterAppListType
        {
            None,
            AppsInListCompliant,
            AppsNotInListCompliant,
        }
        public enum IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameterRequiredPasswordType
        {
            DeviceDefault,
            Alphanumeric,
            Numeric,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
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
        public IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameterAppListType CompliantAppListType { get; set; }
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
        public IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameterRequiredPasswordType PasswordRequiredType { get; set; }
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
    public partial class IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81generalconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81generalconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81generalconfigurationCreateAsync(IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windowsphone81generalconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse> IntuneDeviceconfigWindowsphone81generalconfigurationCreateAsync(IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindowsphone81generalconfigurationCreateParameter, IntuneDeviceconfigWindowsphone81generalconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
