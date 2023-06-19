using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycasePostTagsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum SecurityEdiscoverycasePostTagsParameterSecurityChildSelectability
        {
            One,
            Many,
        }
        public enum EdiscoveryReviewTagSecurityChildSelectability
        {
            One,
            Many,
        }
        public enum ApiPath
        {
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags,
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
        public string? Description { get; set; }
        public SecurityEdiscoverycasePostTagsParameterSecurityChildSelectability ChildSelectability { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EdiscoveryReviewTag[]? ChildTags { get; set; }
        public EdiscoveryReviewTag? Parent { get; set; }
    }
    public partial class SecurityEdiscoverycasePostTagsResponse : RestApiResponse
    {
        public enum EdiscoveryReviewTagSecurityChildSelectability
        {
            One,
            Many,
        }

        public EdiscoveryReviewTagSecurityChildSelectability ChildSelectability { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EdiscoveryReviewTag[]? ChildTags { get; set; }
        public EdiscoveryReviewTag? Parent { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostTagsResponse> SecurityEdiscoverycasePostTagsAsync()
        {
            var p = new SecurityEdiscoverycasePostTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostTagsParameter, SecurityEdiscoverycasePostTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostTagsResponse> SecurityEdiscoverycasePostTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycasePostTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycasePostTagsParameter, SecurityEdiscoverycasePostTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostTagsResponse> SecurityEdiscoverycasePostTagsAsync(SecurityEdiscoverycasePostTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostTagsParameter, SecurityEdiscoverycasePostTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycasePostTagsResponse> SecurityEdiscoverycasePostTagsAsync(SecurityEdiscoverycasePostTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycasePostTagsParameter, SecurityEdiscoverycasePostTagsResponse>(parameter, cancellationToken);
        }
    }
}
