using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/worksheet?view=graph-rest-1.0
/// </summary>
public partial class Worksheet
{
    public enum Worksheetstring
    {
        Visible,
        Hidden,
        VeryHidden,
    }

    public string? Id { get; set; }
    public string? Name { get; set; }
    public int? Position { get; set; }
    public Worksheetstring Visibility { get; set; }
    public Chart[]? Charts { get; set; }
    public NamedItem[]? Names { get; set; }
    public PivotTable[]? PivotTables { get; set; }
    public WorksheetProtection? Protection { get; set; }
    public Table[]? Tables { get; set; }
}
