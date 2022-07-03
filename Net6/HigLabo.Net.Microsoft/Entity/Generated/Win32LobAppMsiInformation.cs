using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-win32lobappmsiinformation?view=graph-rest-1.0
    /// </summary>
    public partial class Win32LobAppMsiInformation
    {
        public string ProductCode { get; set; }
        public string ProductVersion { get; set; }
        public string UpgradeCode { get; set; }
        public bool RequiresReboot { get; set; }
        public Win32LobAppMsiInformationWin32LobAppMsiPackageType PackageType { get; set; }
        public string ProductName { get; set; }
        public string Publisher { get; set; }
    }
}
