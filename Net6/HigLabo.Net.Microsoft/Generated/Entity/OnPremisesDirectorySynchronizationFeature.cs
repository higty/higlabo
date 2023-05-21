using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/onpremisesdirectorysynchronizationfeature?view=graph-rest-1.0
    /// </summary>
    public partial class OnPremisesDirectorySynchronizationFeature
    {
        public bool? BlockCloudObjectTakeoverThroughHardMatchEnabled { get; set; }
        public bool? BlockSoftMatchEnabled { get; set; }
        public bool? BypassDirSyncOverridesEnabled { get; set; }
        public bool? CloudPasswordPolicyForPasswordSyncedUsersEnabled { get; set; }
        public bool? ConcurrentCredentialUpdateEnabled { get; set; }
        public bool? ConcurrentOrgIdProvisioningEnabled { get; set; }
        public bool? DeviceWritebackEnabled { get; set; }
        public bool? DirectoryExtensionsEnabled { get; set; }
        public bool? FopeConflictResolutionEnabled { get; set; }
        public bool? GroupWriteBackEnabled { get; set; }
        public bool? PasswordSyncEnabled { get; set; }
        public bool? PasswordWritebackEnabled { get; set; }
        public bool? QuarantineUponProxyAddressesConflictEnabled { get; set; }
        public bool? QuarantineUponUpnConflictEnabled { get; set; }
        public bool? SoftMatchOnUpnEnabled { get; set; }
        public bool? SynchronizeUpnForManagedUsersEnabled { get; set; }
        public bool? UnifiedGroupWritebackEnabled { get; set; }
        public bool? UserForcePasswordChangeOnLogonEnabled { get; set; }
        public bool? UserWritebackEnabled { get; set; }
    }
}
