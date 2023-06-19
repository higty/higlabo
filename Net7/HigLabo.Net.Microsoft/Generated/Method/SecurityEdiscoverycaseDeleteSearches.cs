using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseDeleteSearchesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoverySearchId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/searches/{EdiscoverySearchId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Searches_EdiscoverySearchId,
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
    public partial class SecurityEdiscoverycaseDeleteSearchesResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseDeleteSearchesResponse> SecurityEdiscoverycaseDeleteSearchesAsync()
        {
            var p = new SecurityEdiscoverycaseDeleteSearchesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseDeleteSearchesParameter, SecurityEdiscoverycaseDeleteSearchesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseDeleteSearchesResponse> SecurityEdiscoverycaseDeleteSearchesAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseDeleteSearchesParameter();
            return await this.SendAsync<SecurityEdiscoverycaseDeleteSearchesParameter, SecurityEdiscoverycaseDeleteSearchesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseDeleteSearchesResponse> SecurityEdiscoverycaseDeleteSearchesAsync(SecurityEdiscoverycaseDeleteSearchesParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseDeleteSearchesParameter, SecurityEdiscoverycaseDeleteSearchesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-searches?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseDeleteSearchesResponse> SecurityEdiscoverycaseDeleteSearchesAsync(SecurityEdiscoverycaseDeleteSearchesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseDeleteSearchesParameter, SecurityEdiscoverycaseDeleteSearchesResponse>(parameter, cancellationToken);
        }
    }
}
