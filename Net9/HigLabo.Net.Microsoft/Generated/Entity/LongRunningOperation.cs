using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/longrunningoperation?view=graph-rest-1.0
/// </summary>
public partial class LongRunningOperation
{
    public enum LongRunningOperationLongRunningOperationStatus
    {
        NotStarted,
        Running,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public string? ResourceLocation { get; set; }
    public LongRunningOperationLongRunningOperationStatus Status { get; set; }
    public string? StatusDetail { get; set; }
}
