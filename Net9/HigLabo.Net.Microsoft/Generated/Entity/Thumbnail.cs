using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/thumbnail?view=graph-rest-1.0
/// </summary>
public partial class Thumbnail
{
    public Stream? Content { get; set; }
    public Int32? Height { get; set; }
    public string? SourceItemId { get; set; }
    public string? Url { get; set; }
    public Int32? Width { get; set; }
}
