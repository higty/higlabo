using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/resources/cloudpcprovisioningpolicyassignment?view=graph-rest-1.0
    /// </summary>
    public partial class CloudPcProvisioningPolicyAssignment
    {
        public string? Id { get; set; }
        public CloudPcManagementAssignmentTarget? Target { get; set; }
        public User[]? AssignedUsers { get; set; }
    }
}
