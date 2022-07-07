using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingCompliancemanagementpartnerDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string ComplianceManagementPartnerId { get; set; }
    }
    public partial class IntuneOnboardingCompliancemanagementpartnerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerDeleteResponse> IntuneOnboardingCompliancemanagementpartnerDeleteAsync()
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerDeleteParameter, IntuneOnboardingCompliancemanagementpartnerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerDeleteResponse> IntuneOnboardingCompliancemanagementpartnerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingCompliancemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerDeleteParameter, IntuneOnboardingCompliancemanagementpartnerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerDeleteResponse> IntuneOnboardingCompliancemanagementpartnerDeleteAsync(IntuneOnboardingCompliancemanagementpartnerDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerDeleteParameter, IntuneOnboardingCompliancemanagementpartnerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-compliancemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingCompliancemanagementpartnerDeleteResponse> IntuneOnboardingCompliancemanagementpartnerDeleteAsync(IntuneOnboardingCompliancemanagementpartnerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingCompliancemanagementpartnerDeleteParameter, IntuneOnboardingCompliancemanagementpartnerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
