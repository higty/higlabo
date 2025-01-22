using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-ipevidence?view=graph-rest-1.0
/// </summary>
public partial class IpEvidence
{
    public string? CountryLetterCode { get; set; }
    public string? IpAddress { get; set; }
}
