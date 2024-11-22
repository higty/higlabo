using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/textwebpart?view=graph-rest-1.0
/// </summary>
public partial class TextWebPart
{
    public string? Id { get; set; }
    public string? InnerHtml { get; set; }
}
