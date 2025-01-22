using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/metadatakeystringpair?view=graph-rest-1.0
/// </summary>
public partial class MetaDataKeyStringPair
{
    public string? Key { get; set; }
    public string? Value { get; set; }
}
