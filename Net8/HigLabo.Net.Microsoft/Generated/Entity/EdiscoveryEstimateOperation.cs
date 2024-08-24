using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/security-ediscoveryestimateoperation?view=graph-rest-1.0
    /// </summary>
    public partial class EDiscoveryEstimateOperation
    {
        public enum EDiscoveryEstimateOperationSecurityCaseAction
        {
            AddToReviewSet,
            ApplyTags,
            ContentExport,
            ConvertToPdf,
            EstimateStatistics,
            PurgeData,
        }
        public enum EDiscoveryEstimateOperationSecurityCaseOperationStatus
        {
            NotStarted,
            SubmissionFailed,
            Running,
            Succeeded,
            PartiallySucceeded,
            Failed,
        }

        public EDiscoveryEstimateOperationSecurityCaseAction Action { get; set; }
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
        public EDiscoveryEstimateOperationSecurityCaseOperationStatus Status { get; set; }
        public Int64? UnindexedItemCount { get; set; }
        public Int64? UnindexedItemsSize { get; set; }
        public EDiscoverySearch? Search { get; set; }
    }
}
