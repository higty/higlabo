using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/callrecords-media?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsMedia
    {
        public string? Label { get; set; }
        public CallrecordsDeviceinfo? CallerDevice { get; set; }
        public CallrecordsNetworkinfo? CallerNetwork { get; set; }
        public CallrecordsDeviceinfo? CalleeDevice { get; set; }
        public CallrecordsNetworkinfo? CalleeNetwork { get; set; }
        public CallrecordsMediastream[]? Streams { get; set; }
    }
}
