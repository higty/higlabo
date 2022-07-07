using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceEnrollmentPlatformRestrictionsConfiguration
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

        public DeviceEnrollmentPlatformRestrictionsConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentplatformrestrictionsconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse> IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListAsync(IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListParameter, IntuneOnboardingDeviceenrollmentplatformrestrictionsconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
