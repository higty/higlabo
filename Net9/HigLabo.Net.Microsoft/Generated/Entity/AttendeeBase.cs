using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attendeebase?view=graph-rest-1.0
/// </summary>
public partial class AttendeeBase
{
    public enum AttendeeBaseAttendeeType
    {
        Required,
        Optional,
        Resource,
    }

    public EmailAddress? EmailAddress { get; set; }
    public AttendeeBaseAttendeeType Type { get; set; }
}
