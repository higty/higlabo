using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiconnectorDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_ApiConnectors_IdentityApiConnectorId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ApiConnectors_IdentityApiConnectorId: return $"/identity/apiConnectors/{IdentityApiConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string IdentityApiConnectorId { get; set; }
    }
    public partial class IdentityapiconnectorDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorDeleteResponse> IdentityapiconnectorDeleteAsync()
        {
            var p = new IdentityapiconnectorDeleteParameter();
            return await this.SendAsync<IdentityapiconnectorDeleteParameter, IdentityapiconnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorDeleteResponse> IdentityapiconnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiconnectorDeleteParameter();
            return await this.SendAsync<IdentityapiconnectorDeleteParameter, IdentityapiconnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorDeleteResponse> IdentityapiconnectorDeleteAsync(IdentityapiconnectorDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityapiconnectorDeleteParameter, IdentityapiconnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorDeleteResponse> IdentityapiconnectorDeleteAsync(IdentityapiconnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiconnectorDeleteParameter, IdentityapiconnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
