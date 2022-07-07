using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappassignmentsettings?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppAssignmentSettings
    {
        public enum Win32LobAppAssignmentSettingsWin32LobAppNotification
        {
            ShowAll,
            ShowReboot,
            HideAll,
        }
        public enum Win32LobAppAssignmentSettingsWin32LobAppDeliveryOptimizationPriority
        {
            NotConfigured,
            Foreground,
        }

        public Win32LobAppNotification Notifications { get; set; }
        public Win32LobAppRestartSettings RestartSettings { get; set; }
        public MobileAppInstallTimeSettings InstallTimeSettings { get; set; }
        public Win32LobAppDeliveryOptimizationPriority DeliveryOptimizationPriority { get; set; }
    }
}
