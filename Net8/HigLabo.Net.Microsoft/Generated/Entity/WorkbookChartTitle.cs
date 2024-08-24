using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookcharttitle?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartTitle
    {
        public bool? Overlay { get; set; }
        public string? Text { get; set; }
        public bool? Visible { get; set; }
        public WorkbookChartTitleFormat? Format { get; set; }
    }
}
