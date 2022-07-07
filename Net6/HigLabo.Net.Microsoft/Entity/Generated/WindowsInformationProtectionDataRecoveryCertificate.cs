using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-windowsinformationprotectiondatarecoverycertificate?view=graph-rest-1.0
    /// </summary>
    public partial class WindowsInformationProtectionDataRecoveryCertificate
    {
        public string? SubjectName { get; set; }
        public string? Description { get; set; }
        public DateTimeOffset? ExpirationDateTime { get; set; }
        public string? Certificate { get; set; }
    }
}
