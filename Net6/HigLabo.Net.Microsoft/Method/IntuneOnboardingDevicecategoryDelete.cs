using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicecategoryDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCategories_DeviceCategoryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCategories_DeviceCategoryId: return $"/deviceManagement/deviceCategories/{DeviceCategoryId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string DeviceCategoryId { get; set; }
    }
    public partial class IntuneOnboardingDevicecategoryDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryDeleteResponse> IntuneOnboardingDevicecategoryDeleteAsync()
        {
            var p = new IntuneOnboardingDevicecategoryDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryDeleteParameter, IntuneOnboardingDevicecategoryDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryDeleteResponse> IntuneOnboardingDevicecategoryDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicecategoryDeleteParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryDeleteParameter, IntuneOnboardingDevicecategoryDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryDeleteResponse> IntuneOnboardingDevicecategoryDeleteAsync(IntuneOnboardingDevicecategoryDeleteParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryDeleteParameter, IntuneOnboardingDevicecategoryDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryDeleteResponse> IntuneOnboardingDevicecategoryDeleteAsync(IntuneOnboardingDevicecategoryDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryDeleteParameter, IntuneOnboardingDevicecategoryDeleteResponse>(parameter, cancellationToken);
        }
    }
}
