using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancedevicestatus?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceComplianceDeviceStatus
    {
        public string Id { get; set; }
        public string DeviceDisplayName { get; set; }
        public string UserName { get; set; }
        public string DeviceModel { get; set; }
        public DateTimeOffset ComplianceGracePeriodExpirationDateTime { get; set; }
        public DeviceComplianceDeviceStatusComplianceStatus Status { get; set; }
        public DateTimeOffset LastReportedDateTime { get; set; }
        public string UserPrincipalName { get; set; }
    }
}
