using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_B2xUserFlows_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_Id: return $"/identity/b2xUserFlows/{Id}";
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
        public string Id { get; set; }
    }
    public partial class B2xidentityuserflowGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? UserFlowType { get; set; }
        public Single? UserFlowTypeVersion { get; set; }
        public UserFlowApiConnectorConfiguration? ApiConnectorConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetResponse> B2xidentityuserflowGetAsync()
        {
            var p = new B2xidentityuserflowGetParameter();
            return await this.SendAsync<B2xidentityuserflowGetParameter, B2xidentityuserflowGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetResponse> B2xidentityuserflowGetAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowGetParameter();
            return await this.SendAsync<B2xidentityuserflowGetParameter, B2xidentityuserflowGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetResponse> B2xidentityuserflowGetAsync(B2xidentityuserflowGetParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowGetParameter, B2xidentityuserflowGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetResponse> B2xidentityuserflowGetAsync(B2xidentityuserflowGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowGetParameter, B2xidentityuserflowGetResponse>(parameter, cancellationToken);
        }
    }
}
