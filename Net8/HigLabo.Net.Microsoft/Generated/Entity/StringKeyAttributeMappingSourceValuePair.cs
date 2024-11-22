using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-stringkeyattributemappingsourcevaluepair?view=graph-rest-1.0
/// </summary>
public partial class StringKeyAttributeMappingSourceValuePair
{
    public string? Key { get; set; }
    public AttributeMappingSource? Value { get; set; }
}
