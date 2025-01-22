using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/sectiongroup?view=graph-rest-1.0
/// </summary>
public partial class SectionGroup
{
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? SectionGroupsUrl { get; set; }
    public string? SectionsUrl { get; set; }
    public string? Self { get; set; }
    public Notebook? ParentNotebook { get; set; }
    public SectionGroup? ParentSectionGroup { get; set; }
    public SectionGroup[]? SectionGroups { get; set; }
    public Section[]? Sections { get; set; }
}
