using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/attachmentitem?view=graph-rest-1.0
/// </summary>
public partial class AttachmentItem
{
    public string? AttachmentType { get; set; }
    public string? ContentId { get; set; }
    public string? ContentType { get; set; }
    public bool? IsInline { get; set; }
    public string? Name { get; set; }
    public Int64? Size { get; set; }
}
