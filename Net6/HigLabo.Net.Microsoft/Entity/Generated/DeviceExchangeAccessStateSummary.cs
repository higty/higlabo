using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-deviceexchangeaccessstatesummary?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceExchangeAccessStateSummary
    {
        public Int32? AllowedDeviceCount { get; set; }
        public Int32? BlockedDeviceCount { get; set; }
        public Int32? QuarantinedDeviceCount { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? UnavailableDeviceCount { get; set; }
    }
}
