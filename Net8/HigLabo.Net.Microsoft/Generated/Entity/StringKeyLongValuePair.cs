using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/synchronization-stringkeylongvaluepair?view=graph-rest-1.0
/// </summary>
public partial class StringKeyLongValuePair
{
    public string? Key { get; set; }
    public Int64? Value { get; set; }
}
