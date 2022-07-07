using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAppsDeviceappmanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAppsDeviceappmanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsDeviceappmanagementGetResponse> IntuneAppsDeviceappmanagementGetAsync()
        {
            var p = new IntuneAppsDeviceappmanagementGetParameter();
            return await this.SendAsync<IntuneAppsDeviceappmanagementGetParameter, IntuneAppsDeviceappmanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsDeviceappmanagementGetResponse> IntuneAppsDeviceappmanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAppsDeviceappmanagementGetParameter();
            return await this.SendAsync<IntuneAppsDeviceappmanagementGetParameter, IntuneAppsDeviceappmanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsDeviceappmanagementGetResponse> IntuneAppsDeviceappmanagementGetAsync(IntuneAppsDeviceappmanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneAppsDeviceappmanagementGetParameter, IntuneAppsDeviceappmanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-apps-deviceappmanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAppsDeviceappmanagementGetResponse> IntuneAppsDeviceappmanagementGetAsync(IntuneAppsDeviceappmanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAppsDeviceappmanagementGetParameter, IntuneAppsDeviceappmanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
