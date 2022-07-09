using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-useragent?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsUseragent
    {
        public string? ApplicationVersion { get; set; }
        public string? HeaderValue { get; set; }
    }
}
