using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/datetimecolumn?view=graph-rest-1.0
/// </summary>
public partial class DateTimeColumn
{
    public string? DisplayAs { get; set; }
    public string? Format { get; set; }
}
