using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-huntingqueryresults?view=graph-rest-1.0
/// </summary>
public partial class HuntingQueryResults
{
    public SinglePropertySchema[]? Schema { get; set; }
    public HuntingRowResult[]? Results { get; set; }
}
