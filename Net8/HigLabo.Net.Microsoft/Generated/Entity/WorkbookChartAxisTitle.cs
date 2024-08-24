using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartaxistitle?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartAxisTitle
    {
        public string? Text { get; set; }
        public bool? Visible { get; set; }
        public WorkbookChartAxisTitleFormat? Format { get; set; }
    }
}
