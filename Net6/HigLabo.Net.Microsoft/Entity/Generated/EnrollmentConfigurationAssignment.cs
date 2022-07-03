using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-enrollmentconfigurationassignment?view=graph-rest-1.0
    /// </summary>
    public partial class EnrollmentConfigurationAssignment
    {
        public string Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
    }
}
