using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-segment?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsSegment
    {
        public CallrecordsEndpoint? Callee { get; set; }
        public CallrecordsEndpoint? Caller { get; set; }
        public DateTimeOffset? EndDateTime { get; set; }
        public CallrecordsFailureinfo? FailureInfo { get; set; }
        public string? Id { get; set; }
        public CallrecordsMedia[]? Media { get; set; }
        public DateTimeOffset? StartDateTime { get; set; }
    }
}
