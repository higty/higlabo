using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookchart?view=graph-rest-1.0
/// </summary>
public partial class WorkbookChart
{
    public Double? Height { get; set; }
    public string? Id { get; set; }
    public Double? Left { get; set; }
    public string? Name { get; set; }
    public Double? Top { get; set; }
    public Double? Width { get; set; }
    public WorkbookChartAxes? Axes { get; set; }
    public WorkbookChartDataLabels? DataLabels { get; set; }
    public WorkbookChartAreaFormat? Format { get; set; }
    public WorkbookChartLegend? Legend { get; set; }
    public WorkbookChartSeries[]? Series { get; set; }
    public WorkbookChartTitle? Title { get; set; }
    public WorkbookWorksheet? Worksheet { get; set; }
}
