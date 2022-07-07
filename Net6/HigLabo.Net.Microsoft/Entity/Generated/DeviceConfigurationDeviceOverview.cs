using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-deviceconfigurationdeviceoverview?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceConfigurationDeviceOverview
    {
        public string? Id { get; set; }
        public Int32? PendingCount { get; set; }
        public Int32? NotApplicableCount { get; set; }
        public Int32? SuccessCount { get; set; }
        public Int32? ErrorCount { get; set; }
        public Int32? FailedCount { get; set; }
        public DateTimeOffset? LastUpdateDateTime { get; set; }
        public Int32? ConfigurationVersion { get; set; }
    }
}
