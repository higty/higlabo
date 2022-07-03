using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-session?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsSession
    {
        public String? Id { get; set; }
        public CallRecordsEndpoint? Caller { get; set; }
        public CallRecordsEndpoint? Callee { get; set; }
        public CallRecordsFailureInfo? FailureInfo { get; set; }
        public CallrecordsSessionCallRecordsModality Modalities { get; set; }
        public DateTimeOffset StartDateTime { get; set; }
        public DateTimeOffset EndDateTime { get; set; }
    }
}
