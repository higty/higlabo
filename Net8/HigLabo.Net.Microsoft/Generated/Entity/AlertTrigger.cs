using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/alerttrigger?view=graph-rest-1.0
/// </summary>
public partial class AlertTrigger
{
    public string? Name { get; set; }
    public string? Type { get; set; }
    public string? Value { get; set; }
}
