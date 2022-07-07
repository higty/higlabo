using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingCompliancemanagementpartnerCreateParameter : IRestApiParameter
    {
        public enum IntuneOnboardingCompliancemanagementpartnerCreateParameterDeviceManagementPartnerTenantState
        {
            Unknown,
            Unavailable,
            Enabled,
            Terminated,
            Rejected,
            Unresponsive,
        }
        public enum ApiPath
        {
            DeviceManagement_ComplianceManagementPartners,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ComplianceManagementPartners: return $"/deviceManagement/complianceManagementPartners";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public DateTimeOffset? LastHeartbeatDateTime { get; set; }
        public IntuneOnboardingCompliancemanagementpartnerCreateParameterDeviceManagementPartnerTenantState PartnerState { get; set; }
        public string? DisplayName { get; set; }
        public bool? MacOsOnboarded { get; set; }
        public bool? AndroidOnboarded { get; set; }
        public bool? IosOnboarded { get; set; }
        public ComplianceManagementPartnerAssignment[]? MacOsEnrollmentAssignments { get; set; }
        public ComplianceManagementPartnerAssignment[]? AndroidEnrollmentAssignments { get; set; }
        public ComplianceManagementPartnerAssignment[]? IosEnrollmentAssignments { get; set; }
    }
    public partial class IntuneOnboardingCompliancemanagementpartnerCreateResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerCreateResponse> IntuneOnboardingCompliancemanagementpartnerCreateAsync()
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerCreateParameter, IntuneOnboardingCompliancemanagementpartnerCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerCreateResponse> IntuneOnboardingCompliancemanagementpartnerCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerCreateParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerCreateParameter, IntuneOnboardingCompliancemanagementpartnerCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerCreateResponse> IntuneOnboardingCompliancemanagementpartnerCreateAsync(IntuneOnboardingCompliancemanagementpartnerCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerCreateParameter, IntuneOnboardingCompliancemanagementpartnerCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerCreateResponse> IntuneOnboardingCompliancemanagementpartnerCreateAsync(IntuneOnboardingCompliancemanagementpartnerCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerCreateParameter, IntuneOnboardingCompliancemanagementpartnerCreateResponse>(parameter, cancellationToken);
        }
    }
}
