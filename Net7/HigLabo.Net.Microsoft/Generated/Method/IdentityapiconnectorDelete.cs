using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
    /// </summary>
    public partial class IdentityapiConnectorDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class IdentityapiConnectorDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityapiConnectorDeleteResponse> IdentityapiConnectorDeleteAsync()
        {
            var p = new IdentityapiConnectorDeleteParameter();
            return await this.SendAsync<IdentityapiConnectorDeleteParameter, IdentityapiConnectorDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityapiConnectorDeleteResponse> IdentityapiConnectorDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new IdentityapiConnectorDeleteParameter();
            return await this.SendAsync<IdentityapiConnectorDeleteParameter, IdentityapiConnectorDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityapiConnectorDeleteResponse> IdentityapiConnectorDeleteAsync(IdentityapiConnectorDeleteParameter parameter)
        {
            return await this.SendAsync<IdentityapiConnectorDeleteParameter, IdentityapiConnectorDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/identityapiconnector-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<IdentityapiConnectorDeleteResponse> IdentityapiConnectorDeleteAsync(IdentityapiConnectorDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<IdentityapiConnectorDeleteParameter, IdentityapiConnectorDeleteResponse>(parameter, cancellationToken);
        }
    }
}
