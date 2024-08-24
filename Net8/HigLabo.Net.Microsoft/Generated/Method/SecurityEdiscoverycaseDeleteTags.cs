using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseDeleteTagsParameter : IRestApiParameter
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
    public partial class SecurityEDiscoverycaseDeleteTagsResponse : RestApiResponse
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
        public async ValueTask<SecurityEDiscoverycaseDeleteTagsResponse> SecurityEDiscoverycaseDeleteTagsAsync()
        {
            var p = new SecurityEDiscoverycaseDeleteTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseDeleteTagsParameter, SecurityEDiscoverycaseDeleteTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseDeleteTagsResponse> SecurityEDiscoverycaseDeleteTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseDeleteTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseDeleteTagsParameter, SecurityEDiscoverycaseDeleteTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseDeleteTagsResponse> SecurityEDiscoverycaseDeleteTagsAsync(SecurityEDiscoverycaseDeleteTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseDeleteTagsParameter, SecurityEDiscoverycaseDeleteTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-delete-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseDeleteTagsResponse> SecurityEDiscoverycaseDeleteTagsAsync(SecurityEDiscoverycaseDeleteTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseDeleteTagsParameter, SecurityEDiscoverycaseDeleteTagsResponse>(parameter, cancellationToken);
        }
    }
}
