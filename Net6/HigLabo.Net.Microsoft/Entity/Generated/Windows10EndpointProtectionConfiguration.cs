using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-windows10endpointprotectionconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class Windows10EndpointProtectionConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public bool FirewallBlockStatefulFTP { get; set; }
        public Int32? FirewallIdleTimeoutForSecurityAssociationInSeconds { get; set; }
        public Windows10EndpointProtectionConfigurationFirewallPreSharedKeyEncodingMethodType FirewallPreSharedKeyEncodingMethod { get; set; }
        public bool FirewallIPSecExemptionsAllowNeighborDiscovery { get; set; }
        public bool FirewallIPSecExemptionsAllowICMP { get; set; }
        public bool FirewallIPSecExemptionsAllowRouterDiscovery { get; set; }
        public bool FirewallIPSecExemptionsAllowDHCP { get; set; }
        public Windows10EndpointProtectionConfigurationFirewallCertificateRevocationListCheckMethodType FirewallCertificateRevocationListCheckMethod { get; set; }
        public bool FirewallMergeKeyingModuleSettings { get; set; }
        public Windows10EndpointProtectionConfigurationFirewallPacketQueueingMethodType FirewallPacketQueueingMethod { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfileDomain { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePublic { get; set; }
        public WindowsFirewallNetworkProfile? FirewallProfilePrivate { get; set; }
        public String[] DefenderAttackSurfaceReductionExcludedPaths { get; set; }
        public String[] DefenderGuardedFoldersAllowedAppPaths { get; set; }
        public String[] DefenderAdditionalGuardedFolders { get; set; }
        public string DefenderExploitProtectionXml { get; set; }
        public string DefenderExploitProtectionXmlFileName { get; set; }
        public bool DefenderSecurityCenterBlockExploitProtectionOverride { get; set; }
        public Windows10EndpointProtectionConfigurationAppLockerApplicationControlType AppLockerApplicationControl { get; set; }
        public bool SmartScreenEnableInShell { get; set; }
        public bool SmartScreenBlockOverrideForFiles { get; set; }
        public bool ApplicationGuardEnabled { get; set; }
        public Windows10EndpointProtectionConfigurationApplicationGuardBlockFileTransferType ApplicationGuardBlockFileTransfer { get; set; }
        public bool ApplicationGuardBlockNonEnterpriseContent { get; set; }
        public bool ApplicationGuardAllowPersistence { get; set; }
        public bool ApplicationGuardForceAuditing { get; set; }
        public Windows10EndpointProtectionConfigurationApplicationGuardBlockClipboardSharingType ApplicationGuardBlockClipboardSharing { get; set; }
        public bool ApplicationGuardAllowPrintToPDF { get; set; }
        public bool ApplicationGuardAllowPrintToXPS { get; set; }
        public bool ApplicationGuardAllowPrintToLocalPrinters { get; set; }
        public bool ApplicationGuardAllowPrintToNetworkPrinters { get; set; }
        public bool BitLockerDisableWarningForOtherDiskEncryption { get; set; }
        public bool BitLockerEnableStorageCardEncryptionOnMobile { get; set; }
        public bool BitLockerEncryptDevice { get; set; }
        public BitLockerRemovableDrivePolicy? BitLockerRemovableDrivePolicy { get; set; }
    }
}
