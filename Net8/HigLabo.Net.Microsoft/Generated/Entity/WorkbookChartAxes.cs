using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartaxes?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartAxes
    {
        public WorkbookChartAxis? CategoryAxis { get; set; }
        public WorkbookChartAxis? SeriesAxis { get; set; }
        public WorkbookChartAxis? ValueAxis { get; set; }
    }
}
