using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappinstallexperience?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppInstallExperience
    {
        public Win32LobAppInstallExperienceRunAsAccountType RunAsAccount { get; set; }
        public Win32LobAppInstallExperienceWin32LobAppRestartBehavior DeviceRestartBehavior { get; set; }
    }
}
