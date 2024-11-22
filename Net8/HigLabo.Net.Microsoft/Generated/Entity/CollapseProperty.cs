using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/collapseproperty?view=graph-rest-1.0
/// </summary>
public partial class CollapseProperty
{
    public String[]? Fields { get; set; }
    public Int16? Limit { get; set; }
}
