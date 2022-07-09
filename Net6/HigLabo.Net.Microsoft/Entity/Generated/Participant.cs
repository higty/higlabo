using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/participant?view=graph-rest-1.0
    /// </summary>
    public partial class Participant
    {
        public string? Id { get; set; }
        public ParticipantInfo? Info { get; set; }
        public bool? IsInLobby { get; set; }
        public bool? IsMuted { get; set; }
        public MediaStream[]? MediaStreams { get; set; }
        public string? Metadata { get; set; }
        public RecordingInfo? RecordingInfo { get; set; }
    }
}
