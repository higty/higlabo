using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-books-managedebookassignment?view=graph-rest-1.0
    /// </summary>
    public partial class ManagedEBookAssignment
    {
        public enum ManagedEBookAssignmentInstallIntent
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
