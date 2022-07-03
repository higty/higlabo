using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationsettingstate?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceConfigurationSettingState
    {
        public string Setting { get; set; }
        public string SettingName { get; set; }
        public string InstanceDisplayName { get; set; }
        public DeviceConfigurationSettingStateComplianceStatus State { get; set; }
        public Int64? ErrorCode { get; set; }
        public string ErrorDescription { get; set; }
        public string UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPrincipalName { get; set; }
        public SettingSource[] Sources { get; set; }
        public string CurrentValue { get; set; }
    }
}
