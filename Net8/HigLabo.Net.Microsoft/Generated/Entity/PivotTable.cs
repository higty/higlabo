using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookpivottable?view=graph-rest-1.0
/// </summary>
public partial class PivotTable
{
    public string? Id { get; set; }
    public string? Name { get; set; }
    public Worksheet? Worksheet { get; set; }
}
