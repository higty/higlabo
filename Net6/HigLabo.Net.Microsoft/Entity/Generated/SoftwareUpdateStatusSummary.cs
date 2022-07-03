using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-softwareupdatestatussummary?view=graph-rest-1.0
    /// </summary>
    public partial class SoftwareUpdateStatusSummary
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public Int32? CompliantDeviceCount { get; set; }
        public Int32? NonCompliantDeviceCount { get; set; }
        public Int32? RemediatedDeviceCount { get; set; }
        public Int32? ErrorDeviceCount { get; set; }
        public Int32? UnknownDeviceCount { get; set; }
        public Int32? ConflictDeviceCount { get; set; }
        public Int32? NotApplicableDeviceCount { get; set; }
        public Int32? CompliantUserCount { get; set; }
        public Int32? NonCompliantUserCount { get; set; }
        public Int32? RemediatedUserCount { get; set; }
        public Int32? ErrorUserCount { get; set; }
        public Int32? UnknownUserCount { get; set; }
        public Int32? ConflictUserCount { get; set; }
        public Int32? NotApplicableUserCount { get; set; }
    }
}
