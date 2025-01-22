using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/section?view=graph-rest-1.0
/// </summary>
public partial class Section
{
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public bool? IsDefault { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public SectionLinks? Links { get; set; }
    public string? PagesUrl { get; set; }
    public string? Self { get; set; }
    public Page[]? Pages { get; set; }
    public Notebook? ParentNotebook { get; set; }
    public SectionGroup? ParentSectionGroup { get; set; }
}
