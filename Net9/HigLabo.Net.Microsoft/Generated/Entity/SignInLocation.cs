using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/signinlocation?view=graph-rest-1.0
/// </summary>
public partial class SignInLocation
{
    public string? City { get; set; }
    public string? CountryOrRegion { get; set; }
    public GeoCoordinates? GeoCoordinates { get; set; }
    public string? State { get; set; }
}
