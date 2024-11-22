using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/security-hostreputation?view=graph-rest-1.0
/// </summary>
public partial class HostReputation
{
    public enum HostReputationSecurityHostReputationClassification
    {
        Unknown,
        Neutral,
        Suspicious,
        Malicious,
        UnknownFutureValue,
    }

    public HostReputationSecurityHostReputationClassification Classification { get; set; }
    public string? Id { get; set; }
    public HostReputationRule[]? Rules { get; set; }
    public Int32? Score { get; set; }
}
