using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneWipDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneWipDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipDevicemanagementGetResponse> IntuneWipDevicemanagementGetAsync()
        {
            var p = new IntuneWipDevicemanagementGetParameter();
            return await this.SendAsync<IntuneWipDevicemanagementGetParameter, IntuneWipDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipDevicemanagementGetResponse> IntuneWipDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneWipDevicemanagementGetParameter();
            return await this.SendAsync<IntuneWipDevicemanagementGetParameter, IntuneWipDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipDevicemanagementGetResponse> IntuneWipDevicemanagementGetAsync(IntuneWipDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneWipDevicemanagementGetParameter, IntuneWipDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-wip-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneWipDevicemanagementGetResponse> IntuneWipDevicemanagementGetAsync(IntuneWipDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneWipDevicemanagementGetParameter, IntuneWipDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
