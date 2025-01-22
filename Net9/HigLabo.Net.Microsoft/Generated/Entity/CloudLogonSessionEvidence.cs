using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-cloudlogonsessionevidence?view=graph-rest-1.0
/// </summary>
public partial class CloudLogonSessionEvidence
{
    public string? SessionId { get; set; }
    public UserEvidence? Account { get; set; }
    public string? Protocol { get; set; }
    public string? DeviceName { get; set; }
    public string? OperatingSystem { get; set; }
    public string? Browser { get; set; }
    public string? UserAgent { get; set; }
    public DateTime? StartUtcDateTime { get; set; }
    public DateTime? PreviousLogonDateTime { get; set; }
}
