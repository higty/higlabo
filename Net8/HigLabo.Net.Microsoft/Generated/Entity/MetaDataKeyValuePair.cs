using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/metadatakeyvaluepair?view=graph-rest-1.0
/// </summary>
public partial class MetaDataKeyValuePair
{
    public string? Key { get; set; }
    public Json? Value { get; set; }
}
