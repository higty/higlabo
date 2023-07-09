using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseCloseParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Close: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/close";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Close,
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
    }
    public partial class SecurityEdiscoverycaseCloseResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseCloseResponse> SecurityEdiscoverycaseCloseAsync()
        {
            var p = new SecurityEdiscoverycaseCloseParameter();
            return await this.SendAsync<SecurityEdiscoverycaseCloseParameter, SecurityEdiscoverycaseCloseResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseCloseResponse> SecurityEdiscoverycaseCloseAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseCloseParameter();
            return await this.SendAsync<SecurityEdiscoverycaseCloseParameter, SecurityEdiscoverycaseCloseResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseCloseResponse> SecurityEdiscoverycaseCloseAsync(SecurityEdiscoverycaseCloseParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseCloseParameter, SecurityEdiscoverycaseCloseResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-close?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseCloseResponse> SecurityEdiscoverycaseCloseAsync(SecurityEdiscoverycaseCloseParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseCloseParameter, SecurityEdiscoverycaseCloseResponse>(parameter, cancellationToken);
        }
    }
}
