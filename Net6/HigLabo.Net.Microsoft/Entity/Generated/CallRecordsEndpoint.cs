using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-endpoint?view=graph-rest-1.0
    /// </summary>
    public partial class CallRecordsEndpoint
    {
        public CallRecordsUserAgent? UserAgent { get; set; }
    }
}
