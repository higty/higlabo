using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartseriesformat?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartSeriesFormat
    {
        public WorkbookChartFill? Fill { get; set; }
        public WorkbookChartLineFormat? Line { get; set; }
    }
}
