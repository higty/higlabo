using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-mam-targetedmanagedapppolicyassignment?view=graph-rest-1.0
    /// </summary>
    public partial class TargetedManagedAppPolicyAssignment
    {
        public string Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
}
