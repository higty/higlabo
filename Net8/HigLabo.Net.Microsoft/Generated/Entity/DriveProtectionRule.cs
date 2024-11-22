using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/driveprotectionrule?view=graph-rest-1.0
/// </summary>
public partial class DriveProtectionRule
{
    public string? Id { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? DriveExpression { get; set; }
    public PublicError? Error { get; set; }
    public bool? IsAutoApplyEnabled { get; set; }
    public IdentitySet? LastModifiedBy { get; set; }
    public DateTimeOffset? LastModifiedDateTime { get; set; }
    public DriveProtectionRule? Status { get; set; }
}
