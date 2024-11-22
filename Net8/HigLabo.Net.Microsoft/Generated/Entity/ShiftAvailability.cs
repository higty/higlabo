using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/shiftavailability?view=graph-rest-1.0
/// </summary>
public partial class ShiftAvailability
{
    public PatternedRecurrence? Recurrence { get; set; }
    public TimeRange[]? TimeSlots { get; set; }
    public string? TimeZone { get; set; }
}
