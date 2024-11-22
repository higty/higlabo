using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-intelligenceprofileindicator?view=graph-rest-1.0
/// </summary>
public partial class IntelligenceProfileIndicator
{
    public enum IntelligenceProfileIndicatorSecurityIndicatorSource
    {
        Microsoft,
        Osint,
        Public,
        UnknownFutureValue,
    }

    public DateTimeOffset? FirstSeenDateTime { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? LastSeenDateTime { get; set; }
    public IntelligenceProfileIndicatorSecurityIndicatorSource Source { get; set; }
    public Artifact? Artifact { get; set; }
}
