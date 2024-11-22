using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/datetimetimezone?view=graph-rest-1.0
/// </summary>
public partial class DateTimeTimeZone
{
    public string? DateTime { get; set; }
    public string? TimeZone { get; set; }
}
