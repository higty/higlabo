using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappinstallexperience?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppInstallExperience
    {
        public enum Win32LobAppInstallExperienceRunAsAccountType
        {
            System,
            User,
        }
        public enum Win32LobAppInstallExperienceWin32LobAppRestartBehavior
        {
            BasedOnReturnCode,
            Allow,
            Suppress,
            Force,
        }

        public RunAsAccountType? RunAsAccount { get; set; }
        public Win32LobAppRestartBehavior? DeviceRestartBehavior { get; set; }
    }
}
