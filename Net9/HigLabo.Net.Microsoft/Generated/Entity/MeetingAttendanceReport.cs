using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/meetingattendancereport?view=graph-rest-1.0
/// </summary>
public partial class MeetingAttendanceReport
{
    public string? Id { get; set; }
    public DateTimeOffset? MeetingEndDateTime { get; set; }
    public DateTimeOffset? MeetingStartDateTime { get; set; }
    public Int32? TotalParticipantCount { get; set; }
    public AttendanceRecord[]? AttendanceRecords { get; set; }
}
