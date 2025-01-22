using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/timeslot?view=graph-rest-1.0
/// </summary>
public partial class TimeSlot
{
    public DateTimeTimeZone? End { get; set; }
    public DateTimeTimeZone? Start { get; set; }
}
