using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IntuneCompanytermsDevicemanagementGetParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class IntuneCompanytermsDevicemanagementGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsDevicemanagementGetResponse> IntuneCompanytermsDevicemanagementGetAsync()
        {
            var p = new IntuneCompanytermsDevicemanagementGetParameter();
            return await this.SendAsync<IntuneCompanytermsDevicemanagementGetParameter, IntuneCompanytermsDevicemanagementGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsDevicemanagementGetResponse> IntuneCompanytermsDevicemanagementGetAsync(CancellationToken cancellationToken)
        {
            var p = new IntuneCompanytermsDevicemanagementGetParameter();
            return await this.SendAsync<IntuneCompanytermsDevicemanagementGetParameter, IntuneCompanytermsDevicemanagementGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsDevicemanagementGetResponse> IntuneCompanytermsDevicemanagementGetAsync(IntuneCompanytermsDevicemanagementGetParameter parameter)
        {
            return await this.SendAsync<IntuneCompanytermsDevicemanagementGetParameter, IntuneCompanytermsDevicemanagementGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/intune-companyterms-devicemanagement-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IntuneCompanytermsDevicemanagementGetResponse> IntuneCompanytermsDevicemanagementGetAsync(IntuneCompanytermsDevicemanagementGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IntuneCompanytermsDevicemanagementGetParameter, IntuneCompanytermsDevicemanagementGetResponse>(parameter, cancellationToken);
        }
    }
}
