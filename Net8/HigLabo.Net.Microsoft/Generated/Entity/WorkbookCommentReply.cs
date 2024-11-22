using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/workbookcommentreply?view=graph-rest-1.0
/// </summary>
public partial class WorkbookCommentReply
{
    public string? Content { get; set; }
    public string? ContentType { get; set; }
    public string? Id { get; set; }
}
