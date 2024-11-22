using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/chatmessageattachment?view=graph-rest-1.0
/// </summary>
public partial class ChatMessageAttachment
{
    public string? Content { get; set; }
    public string? ContentType { get; set; }
    public string? ContentUrl { get; set; }
    public string? Id { get; set; }
    public string? Name { get; set; }
    public string? TeamsAppId { get; set; }
    public string? ThumbnailUrl { get; set; }
}
