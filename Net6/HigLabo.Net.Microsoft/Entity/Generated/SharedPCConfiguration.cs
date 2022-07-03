using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-sharedpcconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class SharedPCConfiguration
    {
        public string Id { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public string Description { get; set; }
        public string DisplayName { get; set; }
        public Int32? Version { get; set; }
        public SharedPCAccountManagerPolicy? AccountManagerPolicy { get; set; }
        public SharedPCConfigurationSharedPCAllowedAccountType AllowedAccounts { get; set; }
        public bool AllowLocalStorage { get; set; }
        public bool DisableAccountManager { get; set; }
        public bool DisableEduPolicies { get; set; }
        public bool DisablePowerPolicies { get; set; }
        public bool DisableSignInOnResume { get; set; }
        public bool Enabled { get; set; }
        public Int32? IdleTimeBeforeSleepInSeconds { get; set; }
        public string KioskAppDisplayName { get; set; }
        public string KioskAppUserModelId { get; set; }
        public TimeOnly MaintenanceStartTime { get; set; }
    }
}
