using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/contenttypeinfo?view=graph-rest-1.0
/// </summary>
public partial class ContentTypeInfo
{
    public string? Id { get; set; }
    public string? Name { get; set; }
}
