using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/defaultcolumnvalue?view=graph-rest-1.0
/// </summary>
public partial class DefaultColumnValue
{
    public string? Formula { get; set; }
    public string? Value { get; set; }
}
