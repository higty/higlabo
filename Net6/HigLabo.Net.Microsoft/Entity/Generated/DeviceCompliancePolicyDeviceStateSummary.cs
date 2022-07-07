using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancepolicydevicestatesummary?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceCompliancePolicyDeviceStateSummary
    {
        public Int32? InGracePeriodCount { get; set; }
        public Int32? ConfigManagerCount { get; set; }
        public string? Id { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
    }
}
