using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/search-acronym?view=graph-rest-1.0
/// </summary>
public partial class Acronym
{
    public enum AcronymSearchAnswerState
    {
        Published,
        Draft,
        Excluded,
        UnknownFutureValue,
    }

    public string? Description { get; set; }
    public string? DisplayName { get; set; }
    public string? Id { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public string? StandsFor { get; set; }
    public AcronymSearchAnswerState State { get; set; }
    public string? WebUrl { get; set; }
}
