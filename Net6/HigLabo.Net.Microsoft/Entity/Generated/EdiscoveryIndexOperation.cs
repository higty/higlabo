using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryindexoperation?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryIndexOperation
    {
        public enum EdiscoveryIndexOperationSecurityCaseAction
        {
            AddToReviewSet,
            ApplyTags,
            ContentExport,
            ConvertToPdf,
            EstimateStatistics,
            PurgeData,
        }
        public enum EdiscoveryIndexOperationSecurityCaseOperationStatus
        {
            NotStarted,
            SubmissionFailed,
            Running,
            Succeeded,
            PartiallySucceeded,
            Failed,
        }

        public CaseOperation? Action { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public Int32? PercentProgress { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public EdiscoveryIndexOperationSecurityCaseOperationStatus Status { get; set; }
    }
}
