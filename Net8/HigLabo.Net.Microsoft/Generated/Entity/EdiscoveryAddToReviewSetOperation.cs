using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryaddtoreviewsetoperation?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryAddToReviewSetOperation
    {
        public enum EdiscoveryAddToReviewSetOperationSecurityCaseAction
        {
            AddToReviewSet,
            ApplyTags,
            ContentExport,
            ConvertToPdf,
            EstimateStatistics,
            PurgeData,
        }
        public enum EdiscoveryAddToReviewSetOperationSecurityCaseOperationStatus
        {
            NotStarted,
            SubmissionFailed,
            Running,
            Succeeded,
            PartiallySucceeded,
            Failed,
        }

        public EdiscoveryAddToReviewSetOperationSecurityCaseAction Action { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public Int32? PercentProgress { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public EdiscoveryAddToReviewSetOperationSecurityCaseOperationStatus Status { get; set; }
        public EdiscoveryReviewSet? ReviewSet { get; set; }
        public EdiscoverySearch? Search { get; set; }
    }
}
