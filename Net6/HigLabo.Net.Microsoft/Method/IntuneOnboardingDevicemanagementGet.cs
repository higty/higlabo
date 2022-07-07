using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement: return $"/deviceManagement";
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
    public partial class IntuneOnboardingDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public IntuneBrand? IntuneBrand { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementGetResponse> IntuneOnboardingDevicemanagementGetAsync()
        {
            var p = new IntuneOnboardingDevicemanagementGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementGetParameter, IntuneOnboardingDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementGetResponse> IntuneOnboardingDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicemanagementGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicemanagementGetParameter, IntuneOnboardingDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementGetResponse> IntuneOnboardingDevicemanagementGetAsync(IntuneOnboardingDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementGetParameter, IntuneOnboardingDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicemanagementGetResponse> IntuneOnboardingDevicemanagementGetAsync(IntuneOnboardingDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicemanagementGetParameter, IntuneOnboardingDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
