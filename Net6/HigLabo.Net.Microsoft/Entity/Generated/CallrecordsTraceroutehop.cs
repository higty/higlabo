using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-traceroutehop?view=graph-rest-1.0
    /// </summary>
    public partial class CallrecordsTraceroutehop
    {
        public Int32? HopCount { get; set; }
        public string? IpAddress { get; set; }
        public string? RoundTripTime { get; set; }
    }
}
