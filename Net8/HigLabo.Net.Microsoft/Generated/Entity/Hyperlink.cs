using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hyperlink?view=graph-rest-1.0
/// </summary>
public partial class Hyperlink
{
    public string? Name { get; set; }
    public string? Url { get; set; }
}
