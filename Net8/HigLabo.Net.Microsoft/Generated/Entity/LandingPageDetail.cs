using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/landingpagedetail?view=graph-rest-1.0
/// </summary>
public partial class LandingPageDetail
{
    public string? Content { get; set; }
    public string? Id { get; set; }
    public bool? IsDefaultLangauge { get; set; }
    public string? Language { get; set; }
}
