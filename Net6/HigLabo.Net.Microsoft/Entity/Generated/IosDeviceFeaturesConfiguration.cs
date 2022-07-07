using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosdevicefeaturesconfiguration?view=graph-rest-1.0
    /// </summary>
    public partial class IosDeviceFeaturesConfiguration
    {
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public Int32? Version { get; set; }
        public string? AssetTagTemplate { get; set; }
        public string? LockScreenFootnote { get; set; }
        public IosHomeScreenItem[]? HomeScreenDockIcons { get; set; }
        public IosHomeScreenPage[]? HomeScreenPages { get; set; }
        public IosNotificationSettings[]? NotificationSettings { get; set; }
    }
}
