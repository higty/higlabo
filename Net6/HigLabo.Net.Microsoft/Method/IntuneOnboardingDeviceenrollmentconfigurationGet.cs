using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceenrollmentconfigurationGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneOnboardingDeviceenrollmentconfigurationGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public Int32? Priority { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public Int32? Version { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationGetResponse> IntuneOnboardingDeviceenrollmentconfigurationGetAsync()
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationGetParameter, IntuneOnboardingDeviceenrollmentconfigurationGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationGetResponse> IntuneOnboardingDeviceenrollmentconfigurationGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceenrollmentconfigurationGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationGetParameter, IntuneOnboardingDeviceenrollmentconfigurationGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationGetResponse> IntuneOnboardingDeviceenrollmentconfigurationGetAsync(IntuneOnboardingDeviceenrollmentconfigurationGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationGetParameter, IntuneOnboardingDeviceenrollmentconfigurationGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceenrollmentconfiguration-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceenrollmentconfigurationGetResponse> IntuneOnboardingDeviceenrollmentconfigurationGetAsync(IntuneOnboardingDeviceenrollmentconfigurationGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceenrollmentconfigurationGetParameter, IntuneOnboardingDeviceenrollmentconfigurationGetResponse>(parameter, cancellationToken);
        }
    }
}
