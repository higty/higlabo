using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentschedule?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedRoleAssignmentSchedule
    {
        public string? AppScopeId { get; set; }
        public string? AssignmentType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CreatedUsing { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? Id { get; set; }
        public string? MemberType { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public string? PrincipalId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public RequestSchedule? ScheduleInfo { get; set; }
        public string? Status { get; set; }
        public UnifiedRoleEligibilitySchedule? ActivatedUsing { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
    }
}
