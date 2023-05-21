using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/riskyuserhistoryitem?view=graph-rest-1.0
    /// </summary>
    public partial class RiskyUserHistoryItem
    {
        public enum RiskyUserHistoryItemRiskDetail
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
        public enum RiskyUserHistoryItemRiskLevel
        {
            Low,
            Medium,
            High,
            Hidden,
            None,
            UnknownFutureValue,
        }
        public enum RiskyUserHistoryItemRiskState
        {
            None,
            ConfirmedSafe,
            Remediated,
            Dismissed,
            AtRisk,
            ConfirmedCompromised,
            UnknownFutureValue,
        }

        public RiskUserActivity? Activity { get; set; }
        public string? Id { get; set; }
        public string? InitiatedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public bool? IsProcessing { get; set; }
        public RiskyUserHistoryItemRiskDetail RiskDetail { get; set; }
        public DateTimeOffset? RiskLastUpdatedDateTime { get; set; }
        public RiskyUserHistoryItemRiskLevel RiskLevel { get; set; }
        public RiskyUserHistoryItemRiskState RiskState { get; set; }
        public string? UserDisplayName { get; set; }
        public string? UserId { get; set; }
        public string? UserPrincipalName { get; set; }
        public RiskyUserHistoryItem[]? History { get; set; }
    }
}
