using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroupassignmentschedule?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessGroupAssignmentSchedule
{
    public enum PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupRelationships
    {
        Owner,
        Member,
        UnknownFutureValue,
        Eq,
    }
    public enum PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupAssignmentType
    {
        Assigned,
        Activated,
        UnknownFutureValue,
        Eq,
    }
    public enum PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupMemberType
    {
        Direct,
        Group,
        UnknownFutureValue,
        Eq,
    }

    public PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupRelationships AccessId { get; set; }
    public PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupAssignmentType AssignmentType { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? CreatedUsing { get; set; }
    public string? GroupId { get; set; }
    public string? Id { get; set; }
    public PrivilegedAccessGroupAssignmentSchedulePrivilegedAccessGroupMemberType MemberType { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public string? PrincipalId { get; set; }
    public RequestSchedule? ScheduleInfo { get; set; }
    public string? Status { get; set; }
    public PrivilegedAccessGroupEligibilitySchedule? ActivatedUsing { get; set; }
    public Group? Group { get; set; }
    public DirectoryObject? Principal { get; set; }
}
