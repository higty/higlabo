using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookchartdatalabels?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookChartDataLabels
    {
        public enum WorkbookChartDataLabelsstring
        {
            None,
            Center,
            InsideEnd,
            InsideBase,
            OutsideEnd,
            Left,
            Right,
            Top,
            Bottom,
            BestFit,
            Callout,
        }

        public WorkbookChartDataLabelsstring Position { get; set; }
        public string? Separator { get; set; }
        public bool? ShowBubbleSize { get; set; }
        public bool? ShowCategoryName { get; set; }
        public bool? ShowLegendKey { get; set; }
        public bool? ShowPercentage { get; set; }
        public bool? ShowSeriesName { get; set; }
        public bool? ShowValue { get; set; }
        public WorkbookChartDataLabelFormat? Format { get; set; }
    }
}
