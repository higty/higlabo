using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/singleuser?view=graph-rest-1.0
/// </summary>
public partial class SingleUser
{
    public string? Description { get; set; }
    public string? UserId { get; set; }
}
