using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations: return $"/deviceManagement/deviceEnrollmentConfigurations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public Int32? Limit { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public Int32? Limit { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationCreateAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
