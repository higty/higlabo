using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancesettingstate?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceComplianceSettingState
    {
        public string Id { get; set; }
        public string Setting { get; set; }
        public string SettingName { get; set; }
        public string DeviceId { get; set; }
        public string DeviceName { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public string UserName { get; set; }
        public string UserPrincipalName { get; set; }
        public string DeviceModel { get; set; }
        public DeviceComplianceSettingStateComplianceStatus State { get; set; }
        public DateTimeOffset ComplianceGracePeriodExpirationDateTime { get; set; }
    }
}
