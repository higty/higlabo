using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-devices-deviceoperatingsystemsummary?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceOperatingSystemSummary
    {
        public Int32? AndroidCount { get; set; }
        public Int32? IosCount { get; set; }
        public Int32? MacOSCount { get; set; }
        public Int32? WindowsMobileCount { get; set; }
        public Int32? WindowsCount { get; set; }
        public Int32? UnknownCount { get; set; }
    }
}
