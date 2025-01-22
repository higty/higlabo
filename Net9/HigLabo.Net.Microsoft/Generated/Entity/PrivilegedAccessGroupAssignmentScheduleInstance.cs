using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroupassignmentscheduleinstance?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessGroupAssignmentScheduleInstance
{
    public enum PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupRelationships
    {
        Owner,
        Member,
        UnknownFutureValue,
        Eq,
    }
    public enum PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupAssignmentType
    {
        Assigned,
        Activated,
        UnknownFutureValue,
        Eq,
    }
    public enum PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupMemberType
    {
        Direct,
        Group,
        UnknownFutureValue,
        Eq,
    }

    public PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupRelationships AccessId { get; set; }
    public string? AssignmentScheduleId { get; set; }
    public PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupAssignmentType AssignmentType { get; set; }
    public DateTimeOffset? EndDateTime { get; set; }
    public string? GroupId { get; set; }
    public string? Id { get; set; }
    public PrivilegedAccessGroupAssignmentScheduleInstancePrivilegedAccessGroupMemberType MemberType { get; set; }
    public string? PrincipalId { get; set; }
    public DateTimeOffset? StartDateTime { get; set; }
    public PrivilegedAccessGroupEligibilityScheduleInstance? ActivatedUsing { get; set; }
    public Group? Group { get; set; }
    public DirectoryObject? Principal { get; set; }
}
