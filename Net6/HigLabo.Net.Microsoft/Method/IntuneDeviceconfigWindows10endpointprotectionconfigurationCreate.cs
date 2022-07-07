using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter : IRestApiParameter
    {
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallPreSharedKeyEncodingMethodType
        {
            DeviceDefault,
            None,
            UtF8,
        }
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallCertificateRevocationListCheckMethodType
        {
            DeviceDefault,
            None,
            Attempt,
            Require,
        }
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallPacketQueueingMethodType
        {
            DeviceDefault,
            Disabled,
            QueueInbound,
            QueueOutbound,
            QueueBoth,
        }
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterAppLockerApplicationControlType
        {
            NotConfigured,
            EnforceComponentsAndStoreApps,
            AuditComponentsAndStoreApps,
            EnforceComponentsStoreAppsAndSmartlocker,
            AuditComponentsStoreAppsAndSmartlocker,
        }
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterApplicationGuardBlockFileTransferType
        {
            NotConfigured,
            BlockImageAndTextFile,
            BlockImageFile,
            BlockNone,
            BlockTextFile,
        }
        public enum IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterApplicationGuardBlockClipboardSharingType
        {
            NotConfigured,
            BlockBoth,
            BlockHostToContainer,
            BlockContainerToHost,
            BlockNone,
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
        public bool? FirewallBlockStatefulFTP { get; set; }
        public Int32? FirewallIdleTimeoutForSecurityAssociationInSeconds { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallPreSharedKeyEncodingMethodType FirewallPreSharedKeyEncodingMethod { get; set; }
        public bool? FirewallIPSecExemptionsAllowNeighborDiscovery { get; set; }
        public bool? FirewallIPSecExemptionsAllowICMP { get; set; }
        public bool? FirewallIPSecExemptionsAllowRouterDiscovery { get; set; }
        public bool? FirewallIPSecExemptionsAllowDHCP { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallCertificateRevocationListCheckMethodType FirewallCertificateRevocationListCheckMethod { get; set; }
        public bool? FirewallMergeKeyingModuleSettings { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterFirewallPacketQueueingMethodType FirewallPacketQueueingMethod { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfileDomain { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePublic { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePrivate { get; set; }
        public String[]? DefenderAttackSurfaceReductionExcludedPaths { get; set; }
        public String[]? DefenderGuardedFoldersAllowedAppPaths { get; set; }
        public String[]? DefenderAdditionalGuardedFolders { get; set; }
        public string? DefenderExploitProtectionXml { get; set; }
        public string? DefenderExploitProtectionXmlFileName { get; set; }
        public bool? DefenderSecurityCenterBlockExploitProtectionOverride { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterAppLockerApplicationControlType AppLockerApplicationControl { get; set; }
        public bool? SmartScreenEnableInShell { get; set; }
        public bool? SmartScreenBlockOverrideForFiles { get; set; }
        public bool? ApplicationGuardEnabled { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterApplicationGuardBlockFileTransferType ApplicationGuardBlockFileTransfer { get; set; }
        public bool? ApplicationGuardBlockNonEnterpriseContent { get; set; }
        public bool? ApplicationGuardAllowPersistence { get; set; }
        public bool? ApplicationGuardForceAuditing { get; set; }
        public IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameterApplicationGuardBlockClipboardSharingType ApplicationGuardBlockClipboardSharing { get; set; }
        public bool? ApplicationGuardAllowPrintToPDF { get; set; }
        public bool? ApplicationGuardAllowPrintToXPS { get; set; }
        public bool? ApplicationGuardAllowPrintToLocalPrinters { get; set; }
        public bool? ApplicationGuardAllowPrintToNetworkPrinters { get; set; }
        public bool? BitLockerDisableWarningForOtherDiskEncryption { get; set; }
        public bool? BitLockerEnableStorageCardEncryptionOnMobile { get; set; }
        public bool? BitLockerEncryptDevice { get; set; }
        public BitLockerRemovableDrivePolicy? BitLockerRemovableDrivePolicy { get; set; }
    }
    public partial class IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse : RestApiResponse
    {
        public enum Windows10EndpointProtectionConfigurationFirewallPreSharedKeyEncodingMethodType
        {
            DeviceDefault,
            None,
            UtF8,
        }
        public enum Windows10EndpointProtectionConfigurationFirewallCertificateRevocationListCheckMethodType
        {
            DeviceDefault,
            None,
            Attempt,
            Require,
        }
        public enum Windows10EndpointProtectionConfigurationFirewallPacketQueueingMethodType
        {
            DeviceDefault,
            Disabled,
            QueueInbound,
            QueueOutbound,
            QueueBoth,
        }
        public enum Windows10EndpointProtectionConfigurationAppLockerApplicationControlType
        {
            NotConfigured,
            EnforceComponentsAndStoreApps,
            AuditComponentsAndStoreApps,
            EnforceComponentsStoreAppsAndSmartlocker,
            AuditComponentsStoreAppsAndSmartlocker,
        }
        public enum Windows10EndpointProtectionConfigurationApplicationGuardBlockFileTransferType
        {
            NotConfigured,
            BlockImageAndTextFile,
            BlockImageFile,
            BlockNone,
            BlockTextFile,
        }
        public enum Windows10EndpointProtectionConfigurationApplicationGuardBlockClipboardSharingType
        {
            NotConfigured,
            BlockBoth,
            BlockHostToContainer,
            BlockContainerToHost,
            BlockNone,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool? FirewallBlockStatefulFTP { get; set; }
        public Int32? FirewallIdleTimeoutForSecurityAssociationInSeconds { get; set; }
        public FirewallPreSharedKeyEncodingMethodType? FirewallPreSharedKeyEncodingMethod { get; set; }
        public bool? FirewallIPSecExemptionsAllowNeighborDiscovery { get; set; }
        public bool? FirewallIPSecExemptionsAllowICMP { get; set; }
        public bool? FirewallIPSecExemptionsAllowRouterDiscovery { get; set; }
        public bool? FirewallIPSecExemptionsAllowDHCP { get; set; }
        public FirewallCertificateRevocationListCheckMethodType? FirewallCertificateRevocationListCheckMethod { get; set; }
        public bool? FirewallMergeKeyingModuleSettings { get; set; }
        public FirewallPacketQueueingMethodType? FirewallPacketQueueingMethod { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfileDomain { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePublic { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePrivate { get; set; }
        public String[]? DefenderAttackSurfaceReductionExcludedPaths { get; set; }
        public String[]? DefenderGuardedFoldersAllowedAppPaths { get; set; }
        public String[]? DefenderAdditionalGuardedFolders { get; set; }
        public string? DefenderExploitProtectionXml { get; set; }
        public string? DefenderExploitProtectionXmlFileName { get; set; }
        public bool? DefenderSecurityCenterBlockExploitProtectionOverride { get; set; }
        public AppLockerApplicationControlType? AppLockerApplicationControl { get; set; }
        public bool? SmartScreenEnableInShell { get; set; }
        public bool? SmartScreenBlockOverrideForFiles { get; set; }
        public bool? ApplicationGuardEnabled { get; set; }
        public ApplicationGuardBlockFileTransferType? ApplicationGuardBlockFileTransfer { get; set; }
        public bool? ApplicationGuardBlockNonEnterpriseContent { get; set; }
        public bool? ApplicationGuardAllowPersistence { get; set; }
        public bool? ApplicationGuardForceAuditing { get; set; }
        public ApplicationGuardBlockClipboardSharingType? ApplicationGuardBlockClipboardSharing { get; set; }
        public bool? ApplicationGuardAllowPrintToPDF { get; set; }
        public bool? ApplicationGuardAllowPrintToXPS { get; set; }
        public bool? ApplicationGuardAllowPrintToLocalPrinters { get; set; }
        public bool? ApplicationGuardAllowPrintToNetworkPrinters { get; set; }
        public bool? BitLockerDisableWarningForOtherDiskEncryption { get; set; }
        public bool? BitLockerEnableStorageCardEncryptionOnMobile { get; set; }
        public bool? BitLockerEncryptDevice { get; set; }
        public BitLockerRemovableDrivePolicy? BitLockerRemovableDrivePolicy { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateAsync()
        {
            var p = new IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter();
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateAsync(IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-windows10endpointprotectionconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse> IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateAsync(IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateParameter, IntuneDeviceconfigWindows10endpointprotectionconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
