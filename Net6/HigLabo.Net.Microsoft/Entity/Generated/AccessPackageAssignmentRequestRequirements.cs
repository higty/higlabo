using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequestrequirements?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentRequestRequirements
    {
        public bool? AllowCustomAssignmentSchedule { get; set; }
        public bool? IsApprovalRequiredForAdd { get; set; }
        public bool? IsApprovalRequiredForUpdate { get; set; }
        public string? PolicyDescription { get; set; }
        public string? PolicyDisplayName { get; set; }
        public string? PolicyId { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
    }
}
