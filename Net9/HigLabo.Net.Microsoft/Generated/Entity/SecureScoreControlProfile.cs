using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/securescorecontrolprofile?view=graph-rest-1.0
/// </summary>
public partial class SecureScoreControlProfile
{
    public string? ActionType { get; set; }
    public string? ActionUrl { get; set; }
    public string? AzureTenantId { get; set; }
    public ComplianceInformation[]? ComplianceInformation { get; set; }
    public string? ControlCategory { get; set; }
    public SecureScoreControlStateUpdate[]? ControlStateUpdates { get; set; }
    public bool? Deprecated { get; set; }
    public string? Id { get; set; }
    public string? ImplementationCost { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public Double? MaxScore { get; set; }
    public Int32? Rank { get; set; }
    public string? Remediation { get; set; }
    public string? RemediationImpact { get; set; }
    public string? Service { get; set; }
    public String[]? Threats { get; set; }
    public string? Tier { get; set; }
    public string? Title { get; set; }
    public string? UserImpact { get; set; }
    public SecurityVendorInformation? VendorInformation { get; set; }
}
