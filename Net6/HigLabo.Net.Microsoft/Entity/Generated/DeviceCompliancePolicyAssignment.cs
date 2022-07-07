using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-deviceconfig-devicecompliancepolicyassignment?view=graph-rest-1.0
    /// </summary>
    public partial class DeviceCompliancePolicyAssignment
    {
        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
}
