using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/table?view=graph-rest-1.0
    /// </summary>
    public partial class Table
    {
        public bool? HighlightFirstColumn { get; set; }
        public bool? HighlightLastColumn { get; set; }
        public string? Id { get; set; }
        public string? LegacyId { get; set; }
        public string? Name { get; set; }
        public bool? ShowBandedRows { get; set; }
        public bool? ShowBandedColumns { get; set; }
        public bool? ShowFilterButton { get; set; }
        public bool? ShowHeaders { get; set; }
        public bool? ShowTotals { get; set; }
        public string? Style { get; set; }
        public WorkbookTableColumn[]? Columns { get; set; }
        public WorkbookTableRow[]? Rows { get; set; }
        public TableSort? Sort { get; set; }
        public Worksheet? Worksheet { get; set; }
    }
}
