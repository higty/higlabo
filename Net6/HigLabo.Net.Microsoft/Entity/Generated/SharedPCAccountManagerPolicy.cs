using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-sharedpcaccountmanagerpolicy?view=graph-rest-1.0
    /// </summary>
    public partial class SharedPCAccountManagerPolicy
    {
        public SharedPCAccountManagerPolicySharedPCAccountDeletionPolicyType AccountDeletionPolicy { get; set; }
        public Int32? CacheAccountsAboveDiskFreePercentage { get; set; }
        public Int32? InactiveThresholdDays { get; set; }
        public Int32? RemoveAccountsBelowDiskFreePercentage { get; set; }
    }
}
