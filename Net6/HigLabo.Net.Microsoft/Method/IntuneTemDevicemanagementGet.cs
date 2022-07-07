using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneTemDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneTemDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemDevicemanagementGetResponse> IntuneTemDevicemanagementGetAsync()
        {
            var p = new IntuneTemDevicemanagementGetParameter();
            return await this.SendAsync<IntuneTemDevicemanagementGetParameter, IntuneTemDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemDevicemanagementGetResponse> IntuneTemDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneTemDevicemanagementGetParameter();
            return await this.SendAsync<IntuneTemDevicemanagementGetParameter, IntuneTemDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemDevicemanagementGetResponse> IntuneTemDevicemanagementGetAsync(IntuneTemDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneTemDevicemanagementGetParameter, IntuneTemDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-tem-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneTemDevicemanagementGetResponse> IntuneTemDevicemanagementGetAsync(IntuneTemDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneTemDevicemanagementGetParameter, IntuneTemDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
