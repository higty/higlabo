using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Organization_OrganizationId_SetMobileDeviceManagementAuthority,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Organization_OrganizationId_SetMobileDeviceManagementAuthority: return $"/organization/{OrganizationId}/setMobileDeviceManagementAuthority";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string OrganizationId { get; set; }
    }
    public partial class IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-setmobiledevicemanagementauthority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse> IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityAsync()
        {
            var p = new IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter, IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-setmobiledevicemanagementauthority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse> IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter();
            return await this.SendAsync<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter, IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-setmobiledevicemanagementauthority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse> IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityAsync(IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter, IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-organization-setmobiledevicemanagementauthority?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse> IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityAsync(IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityParameter, IntuneOnboardingOrganizationSetmobiledevicemanagementauthorityResponse>(parameter, cancellationToken);
        }
    }
}
