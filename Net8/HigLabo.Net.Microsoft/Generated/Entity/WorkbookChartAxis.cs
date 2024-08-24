using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartaxis?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartAxis
    {
        public string? Id { get; set; }
        public Json? MajorUnit { get; set; }
        public Json? Maximum { get; set; }
        public Json? Minimum { get; set; }
        public Json? MinorUnit { get; set; }
        public WorkbookChartAxisFormat? Format { get; set; }
        public WorkbookChartGridlines? MajorGridlines { get; set; }
        public WorkbookChartGridlines? MinorGridlines { get; set; }
        public WorkbookChartAxisTitle? Title { get; set; }
    }
}
