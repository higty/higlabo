using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingCompliancemanagementpartnerListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class IntuneOnboardingCompliancemanagementpartnerListResponse : RestApiResponse
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

        public ComplianceManagementPartner[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerListResponse> IntuneOnboardingCompliancemanagementpartnerListAsync()
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerListParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerListParameter, IntuneOnboardingCompliancemanagementpartnerListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerListResponse> IntuneOnboardingCompliancemanagementpartnerListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerListParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerListParameter, IntuneOnboardingCompliancemanagementpartnerListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerListResponse> IntuneOnboardingCompliancemanagementpartnerListAsync(IntuneOnboardingCompliancemanagementpartnerListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerListParameter, IntuneOnboardingCompliancemanagementpartnerListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerListResponse> IntuneOnboardingCompliancemanagementpartnerListAsync(IntuneOnboardingCompliancemanagementpartnerListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerListParameter, IntuneOnboardingCompliancemanagementpartnerListResponse>(parameter, cancellationToken);
        }
    }
}
