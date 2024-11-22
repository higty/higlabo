using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/datapolicyoperation?view=graph-rest-1.0
/// </summary>
public partial class DataPolicyOperation
{
    public enum DataPolicyOperationDataPolicyOperationStatus
    {
        NotStarted,
        Running,
        Complete,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CompletedDateTime { get; set; }
    public string? Id { get; set; }
    public DataPolicyOperationDataPolicyOperationStatus Status { get; set; }
    public string? StorageLocation { get; set; }
    public string? UserId { get; set; }
    public DateTimeOffset? SubmittedDateTime { get; set; }
    public string? Progress { get; set; }
}
