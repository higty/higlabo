using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-manageddeviceoverview?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedDeviceOverview
    {
        public string Id { get; set; }
        public Int32? EnrolledDeviceCount { get; set; }
        public Int32? MdmEnrolledCount { get; set; }
        public Int32? DualEnrolledDeviceCount { get; set; }
        public DeviceOperatingSystemSummary? DeviceOperatingSystemSummary { get; set; }
        public DeviceExchangeAccessStateSummary? DeviceExchangeAccessStateSummary { get; set; }
    }
}
