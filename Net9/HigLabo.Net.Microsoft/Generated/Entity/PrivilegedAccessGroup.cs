using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/privilegedaccessgroup?view=graph-rest-1.0
/// </summary>
public partial class PrivilegedAccessGroup
{
    public string? Id { get; set; }
    public PrivilegedAccessGroupAssignmentScheduleInstance[]? AssignmentScheduleInstances { get; set; }
    public PrivilegedAccessGroupAssignmentScheduleRequest[]? AssignmentScheduleRequests { get; set; }
    public PrivilegedAccessGroupAssignmentSchedule[]? AssignmentSchedules { get; set; }
    public PrivilegedAccessGroupEligibilityScheduleInstance[]? EligibilityScheduleInstances { get; set; }
    public PrivilegedAccessGroupEligibilityScheduleRequest[]? EligibilityScheduleRequests { get; set; }
    public PrivilegedAccessGroupEligibilitySchedule[]? EligibilitySchedules { get; set; }
}
