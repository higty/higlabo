using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDeviceappmanagementGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceAppManagement,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceAppManagement: return $"/deviceAppManagement";
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
    public partial class IntuneOnboardingDeviceappmanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DateTimeOffset? MicrosoftStoreForBusinessLastSuccessfulSyncDateTime { get; set; }
        public bool? IsEnabledForMicrosoftStoreForBusiness { get; set; }
        public string? MicrosoftStoreForBusinessLanguage { get; set; }
        public DateTimeOffset? MicrosoftStoreForBusinessLastCompletedApplicationSyncTime { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementGetResponse> IntuneOnboardingDeviceappmanagementGetAsync()
        {
            var p = new IntuneOnboardingDeviceappmanagementGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementGetParameter, IntuneOnboardingDeviceappmanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementGetResponse> IntuneOnboardingDeviceappmanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDeviceappmanagementGetParameter();
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementGetParameter, IntuneOnboardingDeviceappmanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementGetResponse> IntuneOnboardingDeviceappmanagementGetAsync(IntuneOnboardingDeviceappmanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementGetParameter, IntuneOnboardingDeviceappmanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDeviceappmanagementGetResponse> IntuneOnboardingDeviceappmanagementGetAsync(IntuneOnboardingDeviceappmanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDeviceappmanagementGetParameter, IntuneOnboardingDeviceappmanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
