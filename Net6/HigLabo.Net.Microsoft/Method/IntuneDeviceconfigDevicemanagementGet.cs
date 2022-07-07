using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneDeviceconfigDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneDeviceconfigDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public DeviceManagementSettings? Settings { get; set; }
        public Guid? IntuneAccountId { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicemanagementGetResponse> IntuneDeviceconfigDevicemanagementGetAsync()
        {
            var p = new IntuneDeviceconfigDevicemanagementGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicemanagementGetParameter, IntuneDeviceconfigDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicemanagementGetResponse> IntuneDeviceconfigDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneDeviceconfigDevicemanagementGetParameter();
            return await this.SendAsync<IntuneDeviceconfigDevicemanagementGetParameter, IntuneDeviceconfigDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicemanagementGetResponse> IntuneDeviceconfigDevicemanagementGetAsync(IntuneDeviceconfigDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicemanagementGetParameter, IntuneDeviceconfigDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-deviceconfig-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneDeviceconfigDevicemanagementGetResponse> IntuneDeviceconfigDevicemanagementGetAsync(IntuneDeviceconfigDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneDeviceconfigDevicemanagementGetParameter, IntuneDeviceconfigDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
