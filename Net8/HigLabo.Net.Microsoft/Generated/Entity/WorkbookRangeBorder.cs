using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookrangeborder?view=graph-rest-1.0
/// </summary>
public partial class WorkbookRangeBorder
{
    public enum WorkbookRangeBorderstring
    {
        EdgeTop,
        EdgeBottom,
        EdgeLeft,
        EdgeRight,
        InsideVertical,
        InsideHorizontal,
        DiagonalDown,
        DiagonalUp,
    }

    public string? Color { get; set; }
    public WorkbookRangeBorderstring Id { get; set; }
    public WorkbookRangeBorderstring SideIndex { get; set; }
    public WorkbookRangeBorderstring Style { get; set; }
    public WorkbookRangeBorderstring Weight { get; set; }
}
