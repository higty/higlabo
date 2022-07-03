using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobapprestartsettings?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppRestartSettings
    {
        public Int32? GracePeriodInMinutes { get; set; }
        public Int32? CountdownDisplayBeforeRestartInMinutes { get; set; }
        public Int32? RestartNotificationSnoozeDurationInMinutes { get; set; }
    }
}
