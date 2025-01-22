using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/riskyuser?view=graph-rest-1.0
/// </summary>
public partial class RiskyUser
{
    public enum RiskyUserRiskDetail
    {
        None,
        AdminGeneratedTemporaryPassword,
        UserPerformedSecuredPasswordChange,
        UserPerformedSecuredPasswordReset,
        AdminConfirmedSigninSafe,
        AiConfirmedSigninSafe,
        UserPassedMFADrivenByRiskBasedPolicy,
        AdminDismissedAllRiskForUser,
        AdminConfirmedSigninCompromised,
        Hidden,
        AdminConfirmedUserCompromised,
        UnknownFutureValue,
    }
    public enum RiskyUserRiskLevel
    {
        Low,
        Medium,
        High,
        Hidden,
        None,
        UnknownFutureValue,
    }
    public enum RiskyUserRiskState
    {
        None,
        ConfirmedSafe,
        Remediated,
        Dismissed,
        AtRisk,
        ConfirmedCompromised,
        UnknownFutureValue,
    }

    public string? Id { get; set; }
    public bool? IsDeleted { get; set; }
    public bool? IsProcessing { get; set; }
    public RiskyUserRiskDetail RiskDetail { get; set; }
    public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
    public RiskyUserRiskLevel RiskLevel { get; set; }
    public RiskyUserRiskState RiskState { get; set; }
    public string? UserDisplayName { get; set; }
    public string? UserPrincipalName { get; set; }
    public RiskyUserHistoryItem[]? History { get; set; }
}
