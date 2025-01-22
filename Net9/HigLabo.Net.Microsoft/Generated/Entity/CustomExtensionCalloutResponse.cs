using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/customextensioncalloutresponse?view=graph-rest-1.0
/// </summary>
public partial class CustomExtensionCalloutResponse
{
    public CustomExtensionData? Data { get; set; }
    public string? Source { get; set; }
    public string? Type { get; set; }
}
