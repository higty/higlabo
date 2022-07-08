using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-session?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsSession
    {
        public enum CallrecordsSessionCallRecordsModality
        {
            Unknown,
            Audio,
            Video,
            VideoBasedScreenSharing,
            Data,
            ScreenSharing,
            UnknownFutureValue,
        }

        public string? Id { get; set; }
        public CallrecordsEndpoint? Caller { get; set; }
        public CallrecordsEndpoint? Callee { get; set; }
        public CallrecordsFailureinfo? FailureInfo { get; set; }
        public CallrecordsSessionCallRecordsModality Modalities { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public CallrecordsSegment[]? Segments { get; set; }
    }
}
