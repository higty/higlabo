using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryestimateoperation?view=graph-rest-1.0
    /// </summary>
    public partial class EdiscoveryEstimateOperation
    {
        public enum EdiscoveryEstimateOperationSecurityCaseAction
        {
            AddToReviewSet,
            ApplyTags,
            ContentExport,
            ConvertToPdf,
            EstimateStatistics,
            PurgeData,
        }
        public enum EdiscoveryEstimateOperationSecurityCaseOperationStatus
        {
            NotStarted,
            SubmissionFailed,
            Running,
            Succeeded,
            PartiallySucceeded,
            Failed,
        }

        public EdiscoveryEstimateOperationSecurityCaseAction Action { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public Int64? IndexedItemCount { get; set; }
        public Int64? IndexedItemsSize { get; set; }
        public Int32? MailboxCount { get; set; }
        public Int32? PercentProgress { get; set; }
        public ResultInfo? ResultInfo { get; set; }
        public Int32? SiteCount { get; set; }
        public EdiscoveryEstimateOperationSecurityCaseOperationStatus Status { get; set; }
        public Int64? UnindexedItemCount { get; set; }
        public Int64? UnindexedItemsSize { get; set; }
        public EdiscoverySearch? Search { get; set; }
    }
}
