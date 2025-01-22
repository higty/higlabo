using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-intelligenceprofile?view=graph-rest-1.0
/// </summary>
public partial class IntelligenceProfile
{
    public enum IntelligenceProfileSecurityIntelligenceProfileKind
    {
        Actor,
        Tool,
        UnknownFutureValue,
    }

    public String[]? Aliases { get; set; }
    public IntelligenceProfileCountryOrRegionOfOrigin[]? CountriesOrRegionsOfOrigin { get; set; }
    public FormattedContent? Description { get; set; }
    public DateTimeOffset? FirstActiveDateTime { get; set; }
    public string? Id { get; set; }
    public IntelligenceProfileSecurityIntelligenceProfileKind Kind { get; set; }
    public FormattedContent? Summary { get; set; }
    public String[]? Targets { get; set; }
    public string? Title { get; set; }
    public FormattedContent? Tradecraft { get; set; }
    public IntelligenceProfileIndicator[]? Indicators { get; set; }
}
