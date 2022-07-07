using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-iosvppebookassignment?view=graph-rest-1.0
    /// </summary>
    public partial class IosVppEBookAssignment
    {
        public enum IosVppEBookAssignmentInstallIntent
        {
            Available,
            Required,
            Uninstall,
            AvailableWithoutEnrollment,
        }

        public string? Id { get; set; }
        public DeviceAndAppManagementAssignmentTarget? Target { get; set; }
        public InstallIntent? InstallIntent { get; set; }
    }
}
