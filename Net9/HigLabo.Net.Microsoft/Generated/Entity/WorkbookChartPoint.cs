using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartpoint?view=graph-rest-1.0
/// </summary>
public partial class WorkbookChartPoint
{
    public string? ID { get; set; }
    public Json? Value { get; set; }
    public WorkbookChartPointFormat? Format { get; set; }
}
