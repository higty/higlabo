using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft;

/// <summary>
/// https://learn.microsoft.com/en-us/graph/api/resources/rbacapplication?view=graph-rest-1.0
/// </summary>
public partial class RbacApplication
{
    public string? Id { get; set; }
    public UnifiedRoleAssignment[]? RoleAssignments { get; set; }
    public UnifiedRoleAssignmentScheduleInstance[]? RoleAssignmentScheduleInstances { get; set; }
    public UnifiedRoleAssignmentScheduleRequest[]? RoleAssignmentScheduleRequests { get; set; }
    public UnifiedRoleAssignmentSchedule[]? RoleAssignmentSchedules { get; set; }
    public UnifiedRoleDefinition[]? RoleDefinitions { get; set; }
    public UnifiedRoleEligibilityScheduleInstance[]? RoleEligibilityScheduleInstances { get; set; }
    public UnifiedRoleEligibilityScheduleRequest[]? RoleEligibilityScheduleRequests { get; set; }
    public UnifiedRoleEligibilitySchedule[]? RoleEligibilitySchedules { get; set; }
}
