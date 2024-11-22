using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroupeligibilityschedule?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessGroupEligibilitySchedule
{
    public enum PrivilegedAccessGroupEligibilitySchedulePrivilegedAccessGroupRelationships
    {
        Owner,
        Member,
        Eq,
    }
    public enum PrivilegedAccessGroupEligibilitySchedulePrivilegedAccessGroupMemberType
    {
        Direct,
        Group,
        UnknownFutureValue,
        Eq,
    }

    public PrivilegedAccessGroupEligibilitySchedulePrivilegedAccessGroupRelationships AccessId { get; set; }
    public DateTimeOffset? CreatedDateTime { get; set; }
    public string? CreatedUsing { get; set; }
    public string? GroupId { get; set; }
    public string? Id { get; set; }
    public PrivilegedAccessGroupEligibilitySchedulePrivilegedAccessGroupMemberType MemberType { get; set; }
    public DateTimeOffset? ModifiedDateTime { get; set; }
    public string? PrincipalId { get; set; }
    public RequestSchedule? ScheduleInfo { get; set; }
    public string? Status { get; set; }
    public Group? Group { get; set; }
    public DirectoryObject? Principal { get; set; }
}
