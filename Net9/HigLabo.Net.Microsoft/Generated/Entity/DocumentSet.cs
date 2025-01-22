using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/documentset?view=graph-rest-1.0
/// </summary>
public partial class DocumentSet
{
    public ContentTypeInfo[]? AllowedContentTypes { get; set; }
    public DocumentSetContent[]? DefaultContents { get; set; }
    public bool? PropagateWelcomePageChanges { get; set; }
    public bool? ShouldPrefixNameToFile { get; set; }
    public string? WelcomePageUrl { get; set; }
    public ColumnDefinition[]? SharedColumns { get; set; }
    public ColumnDefinition[]? WelcomePageColumns { get; set; }
}
