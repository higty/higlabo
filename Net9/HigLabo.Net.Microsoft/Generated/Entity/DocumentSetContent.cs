using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/documentsetcontent?view=graph-rest-1.0
/// </summary>
public partial class DocumentSetContent
{
    public ContentTypeInfo? ContentType { get; set; }
    public string? FileName { get; set; }
    public string? FolderName { get; set; }
}
