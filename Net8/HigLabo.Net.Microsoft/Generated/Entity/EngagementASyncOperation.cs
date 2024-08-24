using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/engagementasyncoperation?view=graph-rest-1.0
    /// </summary>
    public partial class EngagementASyncOperation
    {
        public enum EngagementASyncOperationEngagementAsyncOperationType
        {
            CreateCommunity,
            UnknownFutureValue,
        }
        public enum EngagementASyncOperationLongRunningOperationStatus
        {
            NotStarted,
            Running,
            Succeeded,
            Failed,
            Skipped,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public EngagementASyncOperation? OperationType { get; set; }
        public string? ResourceId { get; set; }
        public string? ResourceLocation { get; set; }
        public EngagementASyncOperationLongRunningOperationStatus Status { get; set; }
        public string? StatusDetail { get; set; }
    }
}
