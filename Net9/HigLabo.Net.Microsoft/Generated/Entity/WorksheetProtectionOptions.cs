using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/worksheetprotectionoptions?view=graph-rest-1.0
/// </summary>
public partial class WorksheetProtectionOptions
{
    public bool? AllowAutoFilter { get; set; }
    public bool? AllowDeleteColumns { get; set; }
    public bool? AllowDeleteRows { get; set; }
    public bool? AllowFormatCells { get; set; }
    public bool? AllowFormatColumns { get; set; }
    public bool? AllowFormatRows { get; set; }
    public bool? AllowInsertColumns { get; set; }
    public bool? AllowInsertHyperlinks { get; set; }
    public bool? AllowInsertRows { get; set; }
    public bool? AllowPivotTables { get; set; }
    public bool? AllowSort { get; set; }
}
