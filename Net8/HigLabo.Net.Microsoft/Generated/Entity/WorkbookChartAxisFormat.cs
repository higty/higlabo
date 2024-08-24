using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartaxisformat?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartAxisFormat
    {
        public WorkbookChartFont? Font { get; set; }
        public WorkbookChartLineFormat? Line { get; set; }
    }
}
