using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicecategoryListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCategories,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCategories: return $"/deviceManagement/deviceCategories";
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
    public partial class IntuneOnboardingDevicecategoryListResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/intune-onboarding-devicecategory?view=graph-rest-1.0
        /// </summary>
        public partial class DeviceCategory
        {
            public string? Id { get; set; }
            public string? DisplayName { get; set; }
            public string? Description { get; set; }
        }

        public DeviceCategory[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryListResponse> IntuneOnboardingDevicecategoryListAsync()
        {
            var p = new IntuneOnboardingDevicecategoryListParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryListParameter, IntuneOnboardingDevicecategoryListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryListResponse> IntuneOnboardingDevicecategoryListAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicecategoryListParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryListParameter, IntuneOnboardingDevicecategoryListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryListResponse> IntuneOnboardingDevicecategoryListAsync(IntuneOnboardingDevicecategoryListParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryListParameter, IntuneOnboardingDevicecategoryListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-list?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryListResponse> IntuneOnboardingDevicecategoryListAsync(IntuneOnboardingDevicecategoryListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryListParameter, IntuneOnboardingDevicecategoryListResponse>(parameter, cancellationToken);
        }
    }
}
