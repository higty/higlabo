using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbooktablerow?view=graph-rest-1.0
/// </summary>
public partial class WorkbookTableRow
{
    public Int32? Index { get; set; }
    public Json? Values { get; set; }
}
