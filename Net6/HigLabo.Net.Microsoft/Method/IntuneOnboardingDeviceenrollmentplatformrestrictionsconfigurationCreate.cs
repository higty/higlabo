using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter : IRestApiParameter
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
        public DeviceEnrollmentPlatformRestriction? IosRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsMobileRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? AndroidRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? MacOSRestriction { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
        public DeviceEnrollmentPlatformRestriction? IosRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? WindowsMobileRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? AndroidRestriction { get; set; }
        public DeviceEnrollmentPlatformRestriction? MacOSRestriction { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationCreateResponse>(parameter, cancellationToken);
        }
    }
}
