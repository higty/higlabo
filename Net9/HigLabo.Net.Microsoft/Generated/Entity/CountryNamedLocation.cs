using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/countrynamedlocation?view=graph-rest-1.0
/// </summary>
public partial class CountryNamedLocation
{
    public enum CountryNamedLocationCountryLookupMethodType
    {
        ClientIpAddress,
        AuthenticatorAppGps,
    }

    public String[]? CountriesAndRegions { get; set; }
    public CountryNamedLocationCountryLookupMethodType CountryLookupMethod { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IncludeUnknownCountriesAndRegions { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
}
