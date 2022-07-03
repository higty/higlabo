using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceEnrollmentPlatformRestrictionsConfiguration
    {
        public string Id { get; set; }
        public string DisplayName { get; set; }
        public string Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public DeviceEnrollmentPlatformRestriction? IosRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsMobileRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? AndroidRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? MacOSRestriction { get; set; }
    }
}
