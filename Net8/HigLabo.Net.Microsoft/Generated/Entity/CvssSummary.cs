using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-cvsssummary?view=graph-rest-1.0
    /// </summary>
    public partial class CvssSummary
    {
        public enum CvssSummarySecurityVulnerabilitySeverity
        {
            None,
            Low,
            Medium,
            High,
            Critical,
            UnknownFutureValue,
        }

        public Double? Score { get; set; }
        public CvssSummarySecurityVulnerabilitySeverity Severity { get; set; }
        public string? VectorString { get; set; }
    }
}
