using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class IdentityapiConnectorGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdentityApiConnectorId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ApiConnectors_IdentityApiConnectorId: return $"/identity/apiConnectors/{IdentityApiConnectorId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Identity_ApiConnectors_IdentityApiConnectorId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
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
    public partial class IdentityapiConnectorGetResponse : RestApiResponse
    {
        public string? Id { get; set; }
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorGetResponse> IdentityapiConnectorGetAsync()
        {
            var p = new IdentityapiConnectorGetParameter();
            return await this.SendAsync<IdentityapiConnectorGetParameter, IdentityapiConnectorGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorGetResponse> IdentityapiConnectorGetAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiConnectorGetParameter();
            return await this.SendAsync<IdentityapiConnectorGetParameter, IdentityapiConnectorGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorGetResponse> IdentityapiConnectorGetAsync(IdentityapiConnectorGetParameter parameter)
        {
            return await this.SendAsync<IdentityapiConnectorGetParameter, IdentityapiConnectorGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/identityapiconnector-get?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorGetResponse> IdentityapiConnectorGetAsync(IdentityapiConnectorGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiConnectorGetParameter, IdentityapiConnectorGetResponse>(parameter, cancellationToken);
        }
    }
}
