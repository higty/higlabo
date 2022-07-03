using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-compliancemanagementpartnerassignment?view=graph-rest-1.0
    /// </summary>
    public partial class ComplianceManagementPartnerAssignment
    {
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
}
