using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/participantinfo?view=graph-rest-1.0
/// </summary>
public partial class ParticipantInfo
{
    public string? CountryCode { get; set; }
    public string? EndpointType { get; set; }
    public IdentitySet? Identity { get; set; }
    public string? LanguageId { get; set; }
    public string? ParticipantId { get; set; }
    public string? Region { get; set; }
}
