using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookrangeview?view=graph-rest-1.0
/// </summary>
public partial class WorkbookRangeView
{
    public Json? CellAddresses { get; set; }
    public Int32? ColumnCount { get; set; }
    public Json? Formulas { get; set; }
    public Json? FormulasLocal { get; set; }
    public Json? FormulasR1C1 { get; set; }
    public Int32? Index { get; set; }
    public Json? NumberFormat { get; set; }
    public Int32? RowCount { get; set; }
    public Json? Text { get; set; }
    public Json? ValueTypes { get; set; }
    public Json? Values { get; set; }
    public WorkbookRangeView[]? Rows { get; set; }
}
