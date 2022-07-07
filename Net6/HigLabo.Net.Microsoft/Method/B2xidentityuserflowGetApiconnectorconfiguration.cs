using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowGetApiconnectorconfigurationParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Dentity_B2xUserFlows_Id_ApiConnectorConfiguration,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Dentity_B2xUserFlows_Id_ApiConnectorConfiguration: return $"/dentity/b2xUserFlows/{Id}/apiConnectorConfiguration";
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
    public partial class B2xidentityuserflowGetApiconnectorconfigurationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetApiconnectorconfigurationResponse> B2xidentityuserflowGetApiconnectorconfigurationAsync()
        {
            var p = new B2xidentityuserflowGetApiconnectorconfigurationParameter();
            return await this.SendAsync<B2xidentityuserflowGetApiconnectorconfigurationParameter, B2xidentityuserflowGetApiconnectorconfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetApiconnectorconfigurationResponse> B2xidentityuserflowGetApiconnectorconfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowGetApiconnectorconfigurationParameter();
            return await this.SendAsync<B2xidentityuserflowGetApiconnectorconfigurationParameter, B2xidentityuserflowGetApiconnectorconfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetApiconnectorconfigurationResponse> B2xidentityuserflowGetApiconnectorconfigurationAsync(B2xidentityuserflowGetApiconnectorconfigurationParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowGetApiconnectorconfigurationParameter, B2xidentityuserflowGetApiconnectorconfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-get-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowGetApiconnectorconfigurationResponse> B2xidentityuserflowGetApiconnectorconfigurationAsync(B2xidentityuserflowGetApiconnectorconfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowGetApiconnectorconfigurationParameter, B2xidentityuserflowGetApiconnectorconfigurationResponse>(parameter, cancellationToken);
        }
    }
}
