using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/callrecords-directroutinglogrow?view=graph-rest-1.0
/// </summary>
public partial class CallrecordsDirectroutinglogrow
{
    public Int32? CallEndSubReason { get; set; }
    public string? CallType { get; set; }
    public string? CalleeNumber { get; set; }
    public string? CallerNumber { get; set; }
    public string? CorrelationId { get; set; }
    public Int32? Duration { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public DateTimeOffset? FailureDateTime { get; set; }
    public string? FinalSipCodePhrase { get; set; }
    public Int32? FinalSipCode { get; set; }
    public string? Id { get; set; }
    public DateTimeOffset? InviteDateTime { get; set; }
    public bool? MediaBypassEnabled { get; set; }
    public string? MediaPathLocation { get; set; }
    public string? SignalingLocation { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public bool? SuccessfulCall { get; set; }
    public string? TrunkFullyQualifiedDomainName { get; set; }
    public string? UserDisplayName { get; set; }
    public string? UserId { get; set; }
    public string? UserPrincipalName { get; set; }
}
