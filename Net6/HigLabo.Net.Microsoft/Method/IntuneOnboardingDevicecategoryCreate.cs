using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicecategoryCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceCategories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCategories: return $"/deviceManagement/deviceCategories";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class IntuneOnboardingDevicecategoryCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryCreateResponse> IntuneOnboardingDevicecategoryCreateAsync()
        {
            var p = new IntuneOnboardingDevicecategoryCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryCreateParameter, IntuneOnboardingDevicecategoryCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryCreateResponse> IntuneOnboardingDevicecategoryCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicecategoryCreateParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryCreateParameter, IntuneOnboardingDevicecategoryCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryCreateResponse> IntuneOnboardingDevicecategoryCreateAsync(IntuneOnboardingDevicecategoryCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryCreateParameter, IntuneOnboardingDevicecategoryCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryCreateResponse> IntuneOnboardingDevicecategoryCreateAsync(IntuneOnboardingDevicecategoryCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryCreateParameter, IntuneOnboardingDevicecategoryCreateResponse>(parameter, cancellationToken);
        }
    }
}
