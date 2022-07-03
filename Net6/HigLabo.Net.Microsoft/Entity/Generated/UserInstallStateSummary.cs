using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-userinstallstatesummary?view=graph-rest-1.0
    /// </summary>
    public partial class UserInstallStateSummary
    {
        public string Id { get; set; }
        public string UserName { get; set; }
        public Int32? InstalledDeviceCount { get; set; }
        public Int32? FailedDeviceCount { get; set; }
        public Int32? NotInstalledDeviceCount { get; set; }
    }
}
