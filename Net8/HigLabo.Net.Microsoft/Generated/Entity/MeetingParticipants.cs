using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/meetingparticipants?view=graph-rest-1.0
/// </summary>
public partial class MeetingParticipants
{
    public MeetingParticipantInfo[]? Attendees { get; set; }
    public MeetingParticipantInfo? Organizer { get; set; }
}
