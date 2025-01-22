using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-singlepropertyschema?view=graph-rest-1.0
/// </summary>
public partial class SinglePropertySchema
{
    public string? Name { get; set; }
    public string? Type { get; set; }
}
