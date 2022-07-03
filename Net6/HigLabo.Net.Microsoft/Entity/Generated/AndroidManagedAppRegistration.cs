using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-androidmanagedappregistration?view=graph-rest-1.0
    /// </summary>
    public partial class AndroidManagedAppRegistration
    {
        public DateTimeOffset CreatedDateTime { get; set; }
        public DateTimeOffset LastSyncDateTime { get; set; }
        public string ApplicationVersion { get; set; }
        public string ManagementSdkVersion { get; set; }
        public string PlatformVersion { get; set; }
        public string DeviceType { get; set; }
        public string DeviceTag { get; set; }
        public string DeviceName { get; set; }
        public ManagedAppFlaggedReason[] FlaggedReasons { get; set; }
        public string UserId { get; set; }
        public MobileAppIdentifier? AppIdentifier { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
    }
}
