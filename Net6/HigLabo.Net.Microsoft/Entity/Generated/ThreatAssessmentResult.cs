using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/threatassessmentresult?view=graph-rest-1.0
    /// </summary>
    public partial class ThreatAssessmentResult
    {
        public enum ThreatAssessmentResultThreatAssessmentResultType
        {
            CheckPolicy,
            Rescan,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public string? Message { get; set; }
        public ThreatAssessmentResultThreatAssessmentResultType ResultType { get; set; }
    }
}
