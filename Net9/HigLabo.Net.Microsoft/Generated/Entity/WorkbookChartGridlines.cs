using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartgridlines?view=graph-rest-1.0
/// </summary>
public partial class WorkbookChartGridlines
{
    public bool? Visible { get; set; }
    public WorkbookChartGridlinesFormat? Format { get; set; }
}
