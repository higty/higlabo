using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingCompliancemanagementpartnerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_ComplianceManagementPartners_ComplianceManagementPartnerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_ComplianceManagementPartners_ComplianceManagementPartnerId: return $"/deviceManagement/complianceManagementPartners/{ComplianceManagementPartnerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string ComplianceManagementPartnerId { get; set; }
    }
    public partial class IntuneOnboardingCompliancemanagementpartnerGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerGetResponse> IntuneOnboardingCompliancemanagementpartnerGetAsync()
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerGetParameter, IntuneOnboardingCompliancemanagementpartnerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerGetResponse> IntuneOnboardingCompliancemanagementpartnerGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerGetParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerGetParameter, IntuneOnboardingCompliancemanagementpartnerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerGetResponse> IntuneOnboardingCompliancemanagementpartnerGetAsync(IntuneOnboardingCompliancemanagementpartnerGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerGetParameter, IntuneOnboardingCompliancemanagementpartnerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerGetResponse> IntuneOnboardingCompliancemanagementpartnerGetAsync(IntuneOnboardingCompliancemanagementpartnerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerGetParameter, IntuneOnboardingCompliancemanagementpartnerGetResponse>(parameter, cancellationToken);
        }
    }
}
