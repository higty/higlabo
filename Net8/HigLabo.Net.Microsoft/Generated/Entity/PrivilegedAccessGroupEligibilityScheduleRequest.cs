using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroupeligibilityschedulerequest?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessGroupEligibilityScheduleRequest
{
    public enum PrivilegedAccessGroupEligibilityScheduleRequestPrivilegedAccessGroupRelationships
    {
        Owner,
        Member,
        UnknownFutureValue,
    }

    public PrivilegedAccessGroupEligibilityScheduleRequestPrivilegedAccessGroupRelationships AccessId { get; set; }
    public string? Action { get; set; }
    public string? ApprovalId { get; set; }
    public DateTimeOffset? CompletedDateTime { get; set; }
    public IdentitySet? CreatedBy { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? CustomData { get; set; }
    public string? GroupId { get; set; }
    public string? Id { get; set; }
    public bool? IsValidationOnly { get; set; }
    public string? Justification { get; set; }
    public string? PrincipalId { get; set; }
    public RequestSchedule? ScheduleInfo { get; set; }
    public string? Status { get; set; }
    public string? TargetScheduleId { get; set; }
    public TicketInfo? TicketInfo { get; set; }
    public Group? Group { get; set; }
    public DirectoryObject? Principal { get; set; }
    public PrivilegedAccessGroupEligibilitySchedule? TargetSchedule { get; set; }
}
