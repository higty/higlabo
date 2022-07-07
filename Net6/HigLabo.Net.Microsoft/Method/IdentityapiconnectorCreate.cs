using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiconnectorCreateParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_ApiConnectors,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ApiConnectors: return $"/identity/apiConnectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class IdentityapiconnectorCreateResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorCreateResponse> IdentityapiconnectorCreateAsync()
        {
            var p = new IdentityapiconnectorCreateParameter();
            return await this.SendAsync<IdentityapiconnectorCreateParameter, IdentityapiconnectorCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorCreateResponse> IdentityapiconnectorCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiconnectorCreateParameter();
            return await this.SendAsync<IdentityapiconnectorCreateParameter, IdentityapiconnectorCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorCreateResponse> IdentityapiconnectorCreateAsync(IdentityapiconnectorCreateParameter parameter)
        {
            return await this.SendAsync<IdentityapiconnectorCreateParameter, IdentityapiconnectorCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiconnectorCreateResponse> IdentityapiconnectorCreateAsync(IdentityapiconnectorCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiconnectorCreateParameter, IdentityapiconnectorCreateResponse>(parameter, cancellationToken);
        }
    }
}
