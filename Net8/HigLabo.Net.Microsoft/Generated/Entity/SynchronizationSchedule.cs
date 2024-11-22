using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-synchronizationschedule?view=graph-rest-1.0
/// </summary>
public partial class SynchronizationSchedule
{
    public enum SynchronizationScheduleSynchronizationScheduleState
    {
        Active,
        Disabled,
        Paused,
    }

    public DateTimeOffset? Expiration { get; set; }
    public string? Interval { get; set; }
    public SynchronizationScheduleSynchronizationScheduleState State { get; set; }
}
