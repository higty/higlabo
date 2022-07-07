using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentlimitconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceEnrollmentLimitConfiguration
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

        public DeviceEnrollmentLimitConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationListAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationListAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationListAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationListParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
