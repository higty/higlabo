using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneRbacDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneRbacDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDevicemanagementGetResponse> IntuneRbacDevicemanagementGetAsync()
        {
            var p = new IntuneRbacDevicemanagementGetParameter();
            return await this.SendAsync<IntuneRbacDevicemanagementGetParameter, IntuneRbacDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDevicemanagementGetResponse> IntuneRbacDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneRbacDevicemanagementGetParameter();
            return await this.SendAsync<IntuneRbacDevicemanagementGetParameter, IntuneRbacDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDevicemanagementGetResponse> IntuneRbacDevicemanagementGetAsync(IntuneRbacDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneRbacDevicemanagementGetParameter, IntuneRbacDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-rbac-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneRbacDevicemanagementGetResponse> IntuneRbacDevicemanagementGetAsync(IntuneRbacDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneRbacDevicemanagementGetParameter, IntuneRbacDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
