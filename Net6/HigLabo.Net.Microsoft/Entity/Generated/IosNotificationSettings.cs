using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-iosnotificationsettings?view=graph-rest-1.0
    /// </summary>
    public partial class IosNotificationSettings
    {
        public enum IosNotificationSettingsIosNotificationAlertType
        {
            DeviceDefault,
            Banner,
            Modal,
            None,
        }

        public string? BundleID { get; set; }
        public string? AppName { get; set; }
        public string? Publisher { get; set; }
        public bool? Enabled { get; set; }
        public bool? ShowInNotificationCenter { get; set; }
        public bool? ShowOnLockScreen { get; set; }
        public IosNotificationAlertType? AlertType { get; set; }
        public bool? BadgesEnabled { get; set; }
        public bool? SoundsEnabled { get; set; }
    }
}
