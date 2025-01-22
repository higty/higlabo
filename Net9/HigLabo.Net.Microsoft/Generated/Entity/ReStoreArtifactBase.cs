using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/restoreartifactbase?view=graph-rest-1.0
/// </summary>
public partial class ReStoreArtifactBase
{
    public enum ReStoreArtifactBaseDestinationType
    {
        New,
        InPlace,
        UnknownFutureValue,
    }
    public enum ReStoreArtifactBaseArtifactRestoreStatus
    {
        Added,
        Scheduling,
        Scheduled,
        InProgress,
        Succeeded,
        Failed,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public DateTimeOffset? CompletionDateTime { get; set; }
    public ReStoreArtifactBaseDestinationType DestinationType { get; set; }
    public PublicError? Error { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public ReStoreArtifactBaseArtifactRestoreStatus Status { get; set; }
    public ReStorePoint? RestorePoint { get; set; }
}
