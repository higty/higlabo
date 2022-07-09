using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/recordinginfo?view=graph-rest-1.0
    /// </summary>
    public partial class RecordingInfo
    {
        public IdentitySet? Initiator { get; set; }
        public string? RecordingStatus { get; set; }
    }
}
