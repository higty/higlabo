using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/pagelinks?view=graph-rest-1.0
/// </summary>
public partial class PageLinks
{
    public ExternalLink? OneNoteClientUrl { get; set; }
    public ExternalLink? OneNoteWebUrl { get; set; }
}
