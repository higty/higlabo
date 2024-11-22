using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/allowedvalue?view=graph-rest-1.0
/// </summary>
public partial class AllowedValue
{
    public string? Id { get; set; }
    public bool? IsActive { get; set; }
}
