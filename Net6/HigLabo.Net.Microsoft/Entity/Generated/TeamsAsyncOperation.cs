using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/teamsasyncoperation?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsAsyncOperation
    {
        public string? Id { get; set; }
        public TeamsAsyncOperationType? OperationType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public TeamsAsyncOperationStatus? Status { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public Int32? AttemptsCount { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
        public OperationError? Error { get; set; }
    }
}
