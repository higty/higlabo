using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-ebookinstallsummary?view=graph-rest-1.0
    /// </summary>
    public partial class EBookInstallSummary
    {
        public string Id { get; set; }
        public Int32? InstalledDeviceCount { get; set; }
        public Int32? FailedDeviceCount { get; set; }
        public Int32? NotInstalledDeviceCount { get; set; }
        public Int32? InstalledUserCount { get; set; }
        public Int32? FailedUserCount { get; set; }
        public Int32? NotInstalledUserCount { get; set; }
    }
}
