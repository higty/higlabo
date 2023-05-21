using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/richlongrunningoperation?view=graph-rest-1.0
    /// </summary>
    public partial class RichLongRunningOperation
    {
        public enum RichLongRunningOperationLongRunningOperationStatus
        {
            NotStarted,
            Running,
            Succeeded,
            Failed,
            UnknownFutureValue,
        }

        public DateTimeOffset? CreatedDateTime { get; set; }
        public PublicError? Error { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public Int32? PercentageComplete { get; set; }
        public string? ResourceId { get; set; }
        public string? ResourceLocation { get; set; }
        public RichLongRunningOperationLongRunningOperationStatus Status { get; set; }
        public string? StatusDetail { get; set; }
        public string? Type { get; set; }
    }
}
