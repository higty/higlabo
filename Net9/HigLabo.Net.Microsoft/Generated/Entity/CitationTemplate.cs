using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-citationtemplate?view=graph-rest-1.0
/// </summary>
public partial class CitationTemplate
{
    public string? CitationJurisdiction { get; set; }
    public string? CitationUrl { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
}
