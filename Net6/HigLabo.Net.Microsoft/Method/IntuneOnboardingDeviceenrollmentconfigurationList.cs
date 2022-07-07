using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentconfigurationListParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneOnboardingDeviceenrollmentconfigurationListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-deviceenrollmentconfiguration?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceEnrollmentConfiguration
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
            public Int32? Priority { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public DateTimeOffset? LastModifiedDateTime { get; set; }
            public Int32? Version { get; set; }
        }

        public DeviceEnrollmentConfiguration[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationListResponse> IntuneOnboardingDeviceenrollmentconfigurationListAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationListParameter, IntuneOnboardingDeviceenrollmentconfigurationListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationListResponse> IntuneOnboardingDeviceenrollmentconfigurationListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationListParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationListParameter, IntuneOnboardingDeviceenrollmentconfigurationListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationListResponse> IntuneOnboardingDeviceenrollmentconfigurationListAsync(IntuneOnboardingDeviceenrollmentconfigurationListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationListParameter, IntuneOnboardingDeviceenrollmentconfigurationListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationListResponse> IntuneOnboardingDeviceenrollmentconfigurationListAsync(IntuneOnboardingDeviceenrollmentconfigurationListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationListParameter, IntuneOnboardingDeviceenrollmentconfigurationListResponse>(parameter, cancellationToken);
        }
    }
}
