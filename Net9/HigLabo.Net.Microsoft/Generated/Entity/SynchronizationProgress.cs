using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationprogress?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationProgress
{
    public Int32? CompletedUnits { get; set; }
    public DateTimeOffset? ProgressObservationDateTime { get; set; }
    public Int32? TotalUnits { get; set; }
    public string? Units { get; set; }
}
