using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/filesecuritystate?view=graph-rest-1.0
    /// </summary>
    public partial class FileSecurityState
    {
        public FileHash? FileHash { get; set; }
        public string? Name { get; set; }
        public string? Path { get; set; }
        public string? RiskScore { get; set; }
    }
}
