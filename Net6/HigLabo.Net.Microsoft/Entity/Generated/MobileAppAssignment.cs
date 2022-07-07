using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-apps-mobileappassignment?view=graph-rest-1.0
    /// </summary>
    public partial class MobileAppAssignment
    {
        public enum MobileAppAssignmentInstallIntent
        {
            Available,
            Required,
            Uninstall,
            AvailableWithoutEnrollment,
        }

        public string? Id { get; set; }
        public InstallIntent? Intent { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public MobileAppAssignmentSettings? Settings { get; set; }
    }
}
