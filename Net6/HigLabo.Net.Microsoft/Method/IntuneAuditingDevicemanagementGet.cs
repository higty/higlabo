using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneAuditingDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneAuditingDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingDevicemanagementGetResponse> IntuneAuditingDevicemanagementGetAsync()
        {
            var p = new IntuneAuditingDevicemanagementGetParameter();
            return await this.SendAsync<IntuneAuditingDevicemanagementGetParameter, IntuneAuditingDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingDevicemanagementGetResponse> IntuneAuditingDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneAuditingDevicemanagementGetParameter();
            return await this.SendAsync<IntuneAuditingDevicemanagementGetParameter, IntuneAuditingDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingDevicemanagementGetResponse> IntuneAuditingDevicemanagementGetAsync(IntuneAuditingDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneAuditingDevicemanagementGetParameter, IntuneAuditingDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-auditing-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneAuditingDevicemanagementGetResponse> IntuneAuditingDevicemanagementGetAsync(IntuneAuditingDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneAuditingDevicemanagementGetParameter, IntuneAuditingDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
