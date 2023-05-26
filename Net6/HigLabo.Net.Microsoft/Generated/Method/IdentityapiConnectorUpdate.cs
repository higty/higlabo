using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityapiConnectorUpdateParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? TargetUrl { get; set; }
        public ApiAuthenticationConfigurationBase? AuthenticationConfiguration { get; set; }
    }
    public partial class IdentityapiConnectorUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUpdateResponse> IdentityapiConnectorUpdateAsync()
        {
            var p = new IdentityapiConnectorUpdateParameter();
            return await this.SendAsync<IdentityapiConnectorUpdateParameter, IdentityapiConnectorUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUpdateResponse> IdentityapiConnectorUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiConnectorUpdateParameter();
            return await this.SendAsync<IdentityapiConnectorUpdateParameter, IdentityapiConnectorUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUpdateResponse> IdentityapiConnectorUpdateAsync(IdentityapiConnectorUpdateParameter parameter)
        {
            return await this.SendAsync<IdentityapiConnectorUpdateParameter, IdentityapiConnectorUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-update?view=graph-rest-1.0
        /// </summary>
        public async Task<IdentityapiConnectorUpdateResponse> IdentityapiConnectorUpdateAsync(IdentityapiConnectorUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiConnectorUpdateParameter, IdentityapiConnectorUpdateResponse>(parameter, cancellationToken);
        }
    }
}
