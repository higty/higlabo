using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/onenoteoperation?view=graph-rest-1.0
/// </summary>
public partial class OnenoteOperation
{
    public enum OnenoteOperationOperationStatus
    {
        NotStarted,
        Running,
        Completed,
        Failed,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public OnenoteOperationError? Error { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastActionDateTime { get; set; }
    public string? PercentComplete { get; set; }
    public string? ResourceId { get; set; }
    public string? ResourceLocation { get; set; }
    public OnenoteOperationOperationStatus Status { get; set; }
}
