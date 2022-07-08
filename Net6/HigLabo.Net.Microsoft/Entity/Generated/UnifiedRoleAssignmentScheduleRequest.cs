using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentschedulerequest?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedRoleAssignmentScheduleRequest
    {
        public string? Action { get; set; }
        public string? ApprovalId { get; set; }
        public string? AppScopeId { get; set; }
        public DateTimeOffset? CompletedDateTime { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CustomData { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? Id { get; set; }
        public bool? IsValidationOnly { get; set; }
        public string? Justification { get; set; }
        public string? PrincipalId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public RequestSchedule? ScheduleInfo { get; set; }
        public string? Status { get; set; }
        public string? TargetScheduleId { get; set; }
        public TicketInfo? TicketInfo { get; set; }
        public UnifiedRoleEligibilitySchedule? ActivatedUsing { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
        public UnifiedRoleAssignmentSchedule? TargetSchedule { get; set; }
    }
}
