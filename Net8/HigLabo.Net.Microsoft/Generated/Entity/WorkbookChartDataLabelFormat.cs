using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartdatalabelformat?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartDataLabelFormat
    {
        public WorkbookChartFill? Fill { get; set; }
        public WorkbookChartFont? Font { get; set; }
    }
}
