using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectionapplockerfile?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionAppLockerFile
    {
        public string DisplayName { get; set; }
        public string FileHash { get; set; }
        public string File { get; set; }
        public string Id { get; set; }
        public string Version { get; set; }
    }
}
