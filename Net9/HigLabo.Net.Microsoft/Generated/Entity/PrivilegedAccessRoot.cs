using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessroot?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessRoot
{
    public string? Id { get; set; }
    public PrivilegedAccessGroup? Group { get; set; }
}
