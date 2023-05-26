using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewtagUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }
            public string? EdiscoveryReviewTagId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags/{EdiscoveryReviewTagId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum SecurityEdiscoveryreviewtagUpdateParameterSecurityChildSelectability
        {
            One,
            Many,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_EdiscoveryReviewTagId,
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
        public string? Description { get; set; }
        public SecurityEdiscoveryreviewtagUpdateParameterSecurityChildSelectability ChildSelectability { get; set; }
    }
    public partial class SecurityEdiscoveryreviewtagUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewtagUpdateResponse> SecurityEdiscoveryreviewtagUpdateAsync()
        {
            var p = new SecurityEdiscoveryreviewtagUpdateParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewtagUpdateParameter, SecurityEdiscoveryreviewtagUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewtagUpdateResponse> SecurityEdiscoveryreviewtagUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewtagUpdateParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewtagUpdateParameter, SecurityEdiscoveryreviewtagUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewtagUpdateResponse> SecurityEdiscoveryreviewtagUpdateAsync(SecurityEdiscoveryreviewtagUpdateParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewtagUpdateParameter, SecurityEdiscoveryreviewtagUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-update?view=graph-rest-1.0
        /// </summary>
        public async Task<SecurityEdiscoveryreviewtagUpdateResponse> SecurityEdiscoveryreviewtagUpdateAsync(SecurityEdiscoveryreviewtagUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewtagUpdateParameter, SecurityEdiscoveryreviewtagUpdateResponse>(parameter, cancellationToken);
        }
    }
}
