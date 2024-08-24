using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartseries?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartSeries
    {
        public string? Name { get; set; }
        public WorkbookChartSeriesFormat? Format { get; set; }
        public WorkbookChartPoint[]? Points { get; set; }
    }
}
