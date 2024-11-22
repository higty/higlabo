using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbooktable?view=graph-rest-1.0
/// </summary>
public partial class WorkbookTable
{
    public enum WorkbookTablestring
    {
        TableStyleLight1,
        TableStyleLight21,
        TableStyleMedium1,
        TableStyleMedium28,
        TableStyleStyleDark1,
        TableStyleStyleDark11,
    }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public bool? ShowHeaders { get; set; }
    public bool? ShowTotals { get; set; }
    public WorkbookTablestring Style { get; set; }
    public bool? HighlightFirstColumn { get; set; }
    public bool? HighlightLastColumn { get; set; }
    public bool? ShowBandedColumns { get; set; }
    public bool? ShowBandedRows { get; set; }
    public bool? ShowFilterButton { get; set; }
    public string? LegacyId { get; set; }
    public WorkbookTableColumn[]? Columns { get; set; }
    public WorkbookTableRow[]? Rows { get; set; }
    public WorkbookTableSort? Sort { get; set; }
    public WorkbookWorksheet? Worksheet { get; set; }
}
