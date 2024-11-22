using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartlegend?view=graph-rest-1.0
/// </summary>
public partial class WorkbookChartLegend
{
    public enum WorkbookChartLegendstring
    {
        Top,
        Bottom,
        Left,
        Right,
        Corner,
        Custom,
    }

    public bool? Overlay { get; set; }
    public WorkbookChartLegendstring Position { get; set; }
    public bool? Visible { get; set; }
    public WorkbookChartLegendFormat? Format { get; set; }
}
