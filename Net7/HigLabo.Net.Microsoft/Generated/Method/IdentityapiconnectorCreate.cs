using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityapiConnectorCreateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ApiConnectors: return $"/identity/apiConnectors";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Identity_ApiConnectors,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
        public string? Id { get; set; }
    }
    public partial class IdentityapiConnectorCreateResponse : RestApiResponse
    {
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? TargetUrl { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorCreateResponse> IdentityapiConnectorCreateAsync()
        {
            var p = new IdentityapiConnectorCreateParameter();
            return await this.SendAsync<IdentityapiConnectorCreateParameter, IdentityapiConnectorCreateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorCreateResponse> IdentityapiConnectorCreateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiConnectorCreateParameter();
            return await this.SendAsync<IdentityapiConnectorCreateParameter, IdentityapiConnectorCreateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorCreateResponse> IdentityapiConnectorCreateAsync(IdentityapiConnectorCreateParameter parameter)
        {
            return await this.SendAsync<IdentityapiConnectorCreateParameter, IdentityapiConnectorCreateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-create?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorCreateResponse> IdentityapiConnectorCreateAsync(IdentityapiConnectorCreateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiConnectorCreateParameter, IdentityapiConnectorCreateResponse>(parameter, cancellationToken);
        }
    }
}
