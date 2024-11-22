using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/termstore-set?view=graph-rest-1.0
/// </summary>
public partial class TermStoreSet
{
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? Id { get; set; }
    public TermStoreLocalizedname[]? LocalizedNames { get; set; }
    public KeyValue[]? Properties { get; set; }
    public TermStoreTerm[]? Children { get; set; }
    public TermStoreGroup? ParentGroup { get; set; }
    public TermStoreRelation[]? Relations { get; set; }
    public TermStoreTerm[]? Terms { get; set; }
}
