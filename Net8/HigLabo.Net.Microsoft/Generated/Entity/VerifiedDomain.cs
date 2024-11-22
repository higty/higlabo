using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/verifieddomain?view=graph-rest-1.0
/// </summary>
public partial class VerifiedDomain
{
    public string? Capabilities { get; set; }
    public bool? IsDefault { get; set; }
    public bool? IsInitial { get; set; }
    public string? Name { get; set; }
    public string? Type { get; set; }
}
