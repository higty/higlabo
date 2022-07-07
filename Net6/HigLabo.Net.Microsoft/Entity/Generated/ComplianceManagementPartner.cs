using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-compliancemanagementpartner?view=graph-rest-1.0
    /// </summary>
    public partial class ComplianceManagementPartner
    {
        public enum ComplianceManagementPartnerDeviceManagementPartnerTenantState
        {
            Unknown,
            Unavailable,
            Enabled,
            Terminated,
            Rejected,
            Unresponsive,
        }

        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public DeviceManagementPartnerTenantState? PartnerState { get; set; }
        public string? DisplayName { get; set; }
        public bool? MacOsOnboarded { get; set; }
        public bool? AndroidOnboarded { get; set; }
        public bool? IosOnboarded { get; set; }
        public ComplianceManagementPartnerAssignment[]? MacOsEnrollmentAssignments { get; set; }
        public ComplianceManagementPartnerAssignment[]? AndroidEnrollmentAssignments { get; set; }
        public ComplianceManagementPartnerAssignment[]? IosEnrollmentAssignments { get; set; }
    }
}
