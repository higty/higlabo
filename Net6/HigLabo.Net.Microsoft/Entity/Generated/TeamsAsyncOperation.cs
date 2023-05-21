using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/teamsasyncoperation?view=graph-rest-1.0
    /// </summary>
    public partial class TeamsASyncOperation
    {
        public Int32? AttemptsCount { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public OperationError? Error { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastActionDateTime { get; set; }
        public TeamsASyncOperationType? OperationType { get; set; }
        public TeamsASyncOperationStatus? Status { get; set; }
        public Guid? TargetResourceId { get; set; }
        public string? TargetResourceLocation { get; set; }
    }
}
