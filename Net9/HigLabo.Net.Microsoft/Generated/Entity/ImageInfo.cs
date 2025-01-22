using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/projectrome-imageinfo?view=graph-rest-1.0
/// </summary>
public partial class ImageInfo
{
    public bool? AddImageQuery { get; set; }
    public string? AlternateText { get; set; }
    public string? IconUrl { get; set; }
}
