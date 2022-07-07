using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/table?view=graph-rest-1.0
    /// </summary>
    public partial class Table
    {
        public string? Id { get; set; }
        public string? Name { get; set; }
        public bool? ShowHeaders { get; set; }
        public bool? ShowTotals { get; set; }
        public string? Style { get; set; }
        public bool? HighlightFirstColumn { get; set; }
        public bool? HighlightLastColumn { get; set; }
        public bool? ShowBandedColumns { get; set; }
        public bool? ShowBandedRows { get; set; }
        public bool? ShowFilterButton { get; set; }
        public string? LegacyId { get; set; }
    }
}
