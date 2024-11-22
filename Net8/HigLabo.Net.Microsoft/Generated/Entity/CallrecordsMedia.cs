using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-media?view=graph-rest-1.0
/// </summary>
public partial class CallrecordsMedia
{
    public CallrecordsDeviceinfo? CalleeDevice { get; set; }
    public CallrecordsNetworkinfo? CalleeNetwork { get; set; }
    public CallrecordsDeviceinfo? CallerDevice { get; set; }
    public CallrecordsNetworkinfo? CallerNetwork { get; set; }
    public string? Label { get; set; }
    public CallrecordsMediastream[]? Streams { get; set; }
}
