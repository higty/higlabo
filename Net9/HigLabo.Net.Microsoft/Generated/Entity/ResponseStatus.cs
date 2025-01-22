using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/responsestatus?view=graph-rest-1.0
/// </summary>
public partial class ResponseStatus
{
    public string? Response { get; set; }
    public DateTimeOffset? Time { get; set; }
}
