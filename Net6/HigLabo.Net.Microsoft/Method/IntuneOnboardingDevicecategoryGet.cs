using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneOnboardingDevicecategoryGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            DeviceManagement_DeviceCategories_DeviceCategoryId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.DeviceManagement_DeviceCategories_DeviceCategoryId: return $"/deviceManagement/deviceCategories/{DeviceCategoryId}";
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
        public string DeviceCategoryId { get; set; }
    }
    public partial class IntuneOnboardingDevicecategoryGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryGetResponse> IntuneOnboardingDevicecategoryGetAsync()
        {
            var p = new IntuneOnboardingDevicecategoryGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryGetParameter, IntuneOnboardingDevicecategoryGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryGetResponse> IntuneOnboardingDevicecategoryGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneOnboardingDevicecategoryGetParameter();
            return await this.SendAsync<IntuneOnboardingDevicecategoryGetParameter, IntuneOnboardingDevicecategoryGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryGetResponse> IntuneOnboardingDevicecategoryGetAsync(IntuneOnboardingDevicecategoryGetParameter parameter)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryGetParameter, IntuneOnboardingDevicecategoryGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-onboarding-devicecategory-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneOnboardingDevicecategoryGetResponse> IntuneOnboardingDevicecategoryGetAsync(IntuneOnboardingDevicecategoryGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneOnboardingDevicecategoryGetParameter, IntuneOnboardingDevicecategoryGetResponse>(parameter, cancellationToken);
        }
    }
}
