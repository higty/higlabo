using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentapprovalsettings?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageAssignmentApprovalSettings
    {
        public bool? IsApprovalRequiredForAdd { get; set; }
        public bool? IsApprovalRequiredForUpdate { get; set; }
        public AccessPackageApprovalStage[]? Stages { get; set; }
    }
}
