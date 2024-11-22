using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/cloudclipboarditempayload?view=graph-rest-1.0
/// </summary>
public partial class CloudClipboardItemPayload
{
    public string? Content { get; set; }
    public string? FormatName { get; set; }
}
