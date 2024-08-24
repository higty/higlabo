using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/workbookrangeformat?view=graph-rest-1.0
    /// </summary>
    public partial class WorkbookRangeFormat
    {
        public enum WorkbookRangeFormatstring
        {
            General,
            Left,
            Center,
            Right,
            Fill,
            Justify,
            CenterAcrossSelection,
            Distributed,
        }

        public Double? ColumnWidth { get; set; }
        public WorkbookRangeFormatstring HorizontalAlignment { get; set; }
        public Double? RowHeight { get; set; }
        public WorkbookRangeFormatstring VerticalAlignment { get; set; }
        public bool? WrapText { get; set; }
        public WorkbookRangeBorder[]? Borders { get; set; }
        public WorkbookRangeFill? Fill { get; set; }
        public WorkbookRangeFont? Font { get; set; }
        public WorkbookFormatProtection? Protection { get; set; }
    }
}
