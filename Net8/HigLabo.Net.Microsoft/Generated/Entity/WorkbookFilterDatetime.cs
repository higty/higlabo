using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/filterdatetime?view=graph-rest-1.0
/// </summary>
public partial class WorkbookFilterDatetime
{
    public string? Date { get; set; }
    public string? Specificity { get; set; }
}
