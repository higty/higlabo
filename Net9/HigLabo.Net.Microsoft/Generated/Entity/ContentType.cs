using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/contenttype?view=graph-rest-1.0
/// </summary>
public partial class ContentType
{
    public String[]? AssociatedHubsUrls { get; set; }
    public string? Description { get; set; }
    public DocumentSet? DocumentSet { get; set; }
    public DocumentSetContent? DocumentTemplate { get; set; }
    public string? Group { get; set; }
    public bool? Hidden { get; set; }
    public string? Id { get; set; }
    public ItemReference? InheritedFrom { get; set; }
    public bool? IsBuiltIn { get; set; }
    public string? Name { get; set; }
    public ContentTypeOrder? Order { get; set; }
    public string? ParentId { get; set; }
    public bool? PropagateChanges { get; set; }
    public bool? ReadOnly { get; set; }
    public bool? Sealed { get; set; }
    public ContentType? Base { get; set; }
    public ColumnLink[]? ColumnLinks { get; set; }
    public ContentType[]? BaseTypes { get; set; }
    public ColumnDefinition[]? ColumnPositions { get; set; }
    public ColumnDefinition[]? Columns { get; set; }
}
