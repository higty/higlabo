using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/callrecording?view=graph-rest-1.0
    /// </summary>
    public partial class CallRecording
    {
        public string? CallId { get; set; }
        public Stream? Content { get; set; }
        public string? ContentCorrelationId { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public string? Id { get; set; }
        public string? MeetingId { get; set; }
        public IdentitySet? MeetingOrganizer { get; set; }
        public string? RecordingContentUrl { get; set; }
    }
}
