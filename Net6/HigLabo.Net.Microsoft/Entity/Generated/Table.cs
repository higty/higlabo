using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/table?view=graph-rest-1.0
    /// </summary>
    public partial class Table
    {
        public String? Id { get; set; }
        public String? Name { get; set; }
        public Boolean? ShowHeaders { get; set; }
        public Boolean? ShowTotals { get; set; }
        public String? Style { get; set; }
        public bool HighlightFirstColumn { get; set; }
        public bool HighlightLastColumn { get; set; }
        public bool ShowBandedColumns { get; set; }
        public bool ShowBandedRows { get; set; }
        public bool ShowFilterButton { get; set; }
        public string LegacyId { get; set; }
    }
}
