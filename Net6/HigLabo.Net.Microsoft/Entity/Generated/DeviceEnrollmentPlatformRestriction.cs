using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentplatformrestriction?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceEnrollmentPlatformRestriction
    {
        public bool PlatformBlocked { get; set; }
        public bool PersonalDeviceEnrollmentBlocked { get; set; }
        public string OsMinimumVersion { get; set; }
        public string OsMaximumVersion { get; set; }
    }
}
