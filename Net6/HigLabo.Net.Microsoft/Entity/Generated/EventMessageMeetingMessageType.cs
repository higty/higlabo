
namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/eventmessage?view=graph-rest-1.0
    /// </summary>
    public enum EventMessageMeetingMessageType
    {
        None,
        MeetingRequest,
        MeetingCancelled,
        MeetingAccepted,
        MeetingTenativelyAccepted,
        MeetingDeclined,
    }
}
