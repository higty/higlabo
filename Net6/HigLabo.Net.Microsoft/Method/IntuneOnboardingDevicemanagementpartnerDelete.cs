using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementpartnerDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceManagementPartners_DeviceManagementPartnerId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceManagementPartners_DeviceManagementPartnerId: return $"/deviceManagement/deviceManagementPartners/{DeviceManagementPartnerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceManagementPartnerId { get; set; }
    }
    public partial class IntuneOnboardingDevicemanagementpartnerDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerDeleteResponse> IntuneOnboardingDevicemanagementpartnerDeleteAsync()
        {
            var p = new IntuneOnboardingDevicemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerDeleteParameter, IntuneOnboardingDevicemanagementpartnerDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerDeleteResponse> IntuneOnboardingDevicemanagementpartnerDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementpartnerDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerDeleteParameter, IntuneOnboardingDevicemanagementpartnerDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerDeleteResponse> IntuneOnboardingDevicemanagementpartnerDeleteAsync(IntuneOnboardingDevicemanagementpartnerDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerDeleteParameter, IntuneOnboardingDevicemanagementpartnerDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagementpartner-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementpartnerDeleteResponse> IntuneOnboardingDevicemanagementpartnerDeleteAsync(IntuneOnboardingDevicemanagementpartnerDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementpartnerDeleteParameter, IntuneOnboardingDevicemanagementpartnerDeleteResponse>(parameter, cancellationToken);
        }
    }
}
