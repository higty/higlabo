using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/partners-billing-operation?view=graph-rest-1.0
/// </summary>
public partial class Operation
{
    public enum OperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Completed,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public OperationLongRunningOperationStatus Status { get; set; }
}
