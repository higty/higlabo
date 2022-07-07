using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationGetAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationGetAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentlimitconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse> IntuneOnboardingDeviceenrollmentlimitconfigurationGetAsync(IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentlimitconfigurationGetParameter, IntuneOnboardingDeviceenrollmentlimitconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
