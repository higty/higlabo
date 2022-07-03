using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-failureinfo?view=graph-rest-1.0
    /// </summary>
    public partial class CallRecordsFailureInfo
    {
        public string Reason { get; set; }
        public CallRecordsFailureInfoCallRecordsFailureStage Stage { get; set; }
    }
}
