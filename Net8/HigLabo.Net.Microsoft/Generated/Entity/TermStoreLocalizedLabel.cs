using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/termstore-localizedlabel?view=graph-rest-1.0
/// </summary>
public partial class TermStoreLocalizedlabel
{
    public bool? IsDefault { get; set; }
    public string? LanguageTag { get; set; }
    public string? Name { get; set; }
}
