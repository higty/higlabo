using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/publicationfacet?view=graph-rest-1.0
/// </summary>
public partial class PublicationFacet
{
    public string? Level { get; set; }
    public string? VersionId { get; set; }
}
