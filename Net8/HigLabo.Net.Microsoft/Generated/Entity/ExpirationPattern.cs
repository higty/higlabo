using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/expirationpattern?view=graph-rest-1.0
/// </summary>
public partial class ExpirationPattern
{
    public enum ExpirationPatternExpirationPatternType
    {
        NotSpecified,
        NoExpiration,
        AfterDateTime,
        AfterDuration,
    }

    public string? Duration { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public ExpirationPatternExpirationPatternType Type { get; set; }
}
