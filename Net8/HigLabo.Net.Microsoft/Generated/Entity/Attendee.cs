using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attendee?view=graph-rest-1.0
/// </summary>
public partial class Attendee
{
    public EmailAddress? EmailAddress { get; set; }
    public TimeSlot? ProposedNewTime { get; set; }
    public ResponseStatus? Status { get; set; }
    public string? Type { get; set; }
}
