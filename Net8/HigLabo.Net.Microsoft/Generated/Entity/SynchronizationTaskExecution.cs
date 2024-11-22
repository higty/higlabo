using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationtaskexecution?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationTaskExecution
{
    public enum SynchronizationTaskExecutionSynchronizationTaskExecutionResult
    {
        Succeeded,
        Failed,
        EntryLevelErrors,
    }

    public string? ActivityIdentifier { get; set; }
    public Int64? CountEntitled { get; set; }
    public Int64? CountEntitledForProvisioning { get; set; }
    public Int64? CountEscrowed { get; set; }
    public Int64? CountEscrowedRaw { get; set; }
    public Int64? CountExported { get; set; }
    public Int64? CountExports { get; set; }
    public Int64? CountImported { get; set; }
    public Int64? CountImportedDeltas { get; set; }
    public Int64? CountImportedReferenceDeltas { get; set; }
    public SynchronizationError? Error { get; set; }
    public SynchronizationTaskExecutionSynchronizationTaskExecutionResult State { get; set; }
    public DateTimeOffset? TimeBegan { get; set; }
    public DateTimeOffset? TimeEnded { get; set; }
}
