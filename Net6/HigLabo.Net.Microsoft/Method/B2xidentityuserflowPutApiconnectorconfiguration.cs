using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class B2xidentityuserflowPutApiconnectorconfigurationParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_B2xUserFlows_B2xUserFlowId_ApiConnectorConfiguration_Step_ref,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_B2xUserFlows_B2xUserFlowId_ApiConnectorConfiguration_Step_ref: return $"/identity/b2xUserFlows/{B2xUserFlowId}/apiConnectorConfiguration/{Step}/$ref";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PUT";
        public string B2xUserFlowId { get; set; }
        public string Step { get; set; }
    }
    public partial class B2xidentityuserflowPutApiconnectorconfigurationResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPutApiconnectorconfigurationResponse> B2xidentityuserflowPutApiconnectorconfigurationAsync()
        {
            var p = new B2xidentityuserflowPutApiconnectorconfigurationParameter();
            return await this.SendAsync<B2xidentityuserflowPutApiconnectorconfigurationParameter, B2xidentityuserflowPutApiconnectorconfigurationResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPutApiconnectorconfigurationResponse> B2xidentityuserflowPutApiconnectorconfigurationAsync(CancellationToken cancellationToken)
        {
            var p = new B2xidentityuserflowPutApiconnectorconfigurationParameter();
            return await this.SendAsync<B2xidentityuserflowPutApiconnectorconfigurationParameter, B2xidentityuserflowPutApiconnectorconfigurationResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPutApiconnectorconfigurationResponse> B2xidentityuserflowPutApiconnectorconfigurationAsync(B2xidentityuserflowPutApiconnectorconfigurationParameter parameter)
        {
            return await this.SendAsync<B2xidentityuserflowPutApiconnectorconfigurationParameter, B2xidentityuserflowPutApiconnectorconfigurationResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/b2xidentityuserflow-put-apiconnectorconfiguration?view=graph-rest-1.0
        /// </summary>
        public async Task<B2xidentityuserflowPutApiconnectorconfigurationResponse> B2xidentityuserflowPutApiconnectorconfigurationAsync(B2xidentityuserflowPutApiconnectorconfigurationParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<B2xidentityuserflowPutApiconnectorconfigurationParameter, B2xidentityuserflowPutApiconnectorconfigurationResponse>(parameter, cancellationToken);
        }
    }
}
