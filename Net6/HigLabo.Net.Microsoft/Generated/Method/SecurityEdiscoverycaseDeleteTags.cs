using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseDeleteTagsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? TagId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_TagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags/{TagId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_TagId,
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
    public partial class SecurityEdiscoverycaseDeleteTagsResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseDeleteTagsResponse> SecurityEdiscoverycaseDeleteTagsAsync()
        {
            var p = new SecurityEdiscoverycaseDeleteTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseDeleteTagsParameter, SecurityEdiscoverycaseDeleteTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseDeleteTagsResponse> SecurityEdiscoverycaseDeleteTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseDeleteTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseDeleteTagsParameter, SecurityEdiscoverycaseDeleteTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseDeleteTagsResponse> SecurityEdiscoverycaseDeleteTagsAsync(SecurityEdiscoverycaseDeleteTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseDeleteTagsParameter, SecurityEdiscoverycaseDeleteTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoverycaseDeleteTagsResponse> SecurityEdiscoverycaseDeleteTagsAsync(SecurityEdiscoverycaseDeleteTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseDeleteTagsParameter, SecurityEdiscoverycaseDeleteTagsResponse>(parameter, cancellationToken);
        }
    }
}
