using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/termstore-group?view=graph-rest-1.0
/// </summary>
public partial class TermStoreGroup
{
    public enum TermStoreGroupstring
    {
        Global,
        System,
        SiteCollection,
    }

    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public string? ParentSiteId { get; set; }
    public TermStoreGroupstring Scope { get; set; }
    public TermStoreSet[]? Sets { get; set; }
}
