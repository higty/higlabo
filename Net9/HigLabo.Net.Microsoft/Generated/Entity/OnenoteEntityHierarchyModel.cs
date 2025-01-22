using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/onenoteentityhierarchymodel?view=graph-rest-1.0
/// </summary>
public partial class OnenoteEntityHierarchyModel
{
    public string? DisplayName { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
}
