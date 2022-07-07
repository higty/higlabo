using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceEnrollmentConfigurations_DeviceEnrollmentConfigurationId: return $"/deviceManagement/deviceEnrollmentConfigurations/{DeviceEnrollmentConfigurationId}";
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
        public string DeviceEnrollmentConfigurationId { get; set; }
    }
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
