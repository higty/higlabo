using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chartaxis?view=graph-rest-1.0
/// </summary>
public partial class ChartAxis
{
    public string? Id { get; set; }
    public Json? MajorUnit { get; set; }
    public Json? Maximum { get; set; }
    public Json? Minimum { get; set; }
    public Json? MinorUnit { get; set; }
    public ChartAxisFormat? Format { get; set; }
    public ChartGridlines? MajorGridlines { get; set; }
    public ChartGridlines? MinorGridlines { get; set; }
    public ChartAxisTitle? Title { get; set; }
}
