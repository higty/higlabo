using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/securescore?view=graph-rest-1.0
/// </summary>
public partial class SecureScore
{
    public Int32? ActiveUserCount { get; set; }
    public AverageComparativeScore[]? AverageComparativeScores { get; set; }
    public string? AzureTenantId { get; set; }
    public ControlScore[]? ControlScores { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public Double? CurrentScore { get; set; }
    public String[]? EnabledServices { get; set; }
    public string? Id { get; set; }
    public Int32? LicensedUserCount { get; set; }
    public Double? MaxScore { get; set; }
    public SecurityVendorInformation? VendorInformation { get; set; }
}
