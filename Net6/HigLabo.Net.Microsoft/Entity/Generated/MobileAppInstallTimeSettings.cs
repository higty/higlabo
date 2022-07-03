using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappinstalltimesettings?view=graph-rest-1.0
    /// </summary>
    public partial class MobileAppInstallTimeSettings
    {
        public bool UseLocalTime { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset DeadlineDateTime { get; set; }
    }
}
