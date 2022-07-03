using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/meetingparticipantinfo?view=graph-rest-1.0
    /// </summary>
    public partial class MeetingParticipantInfo
    {
        public IdentitySet? Identity { get; set; }
        public string Upn { get; set; }
        public MeetingParticipantInfoOnlineMeetingRole Role { get; set; }
    }
}
