using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycasePostTagsParameter : IRestApiParameter
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

        public enum SecurityEDiscoverycasePostTagsParameterSecurityChildSelectability
        {
            One,
            Many,
        }
        public enum EDiscoveryReviewTagSecurityChildSelectability
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
        public SecurityEDiscoverycasePostTagsParameterSecurityChildSelectability ChildSelectability { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EDiscoveryReviewTag[]? ChildTags { get; set; }
        public EDiscoveryReviewTag? Parent { get; set; }
    }
    public partial class SecurityEDiscoverycasePostTagsResponse : RestApiResponse
    {
        public enum EDiscoveryReviewTagSecurityChildSelectability
        {
            One,
            Many,
        }

        public EDiscoveryReviewTagSecurityChildSelectability ChildSelectability { get; set; }
        public IdentitySet? CreatedBy { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? LastModifiedDateTime { get; set; }
        public EDiscoveryReviewTag[]? ChildTags { get; set; }
        public EDiscoveryReviewTag? Parent { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostTagsResponse> SecurityEDiscoverycasePostTagsAsync()
        {
            var p = new SecurityEDiscoverycasePostTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycasePostTagsParameter, SecurityEDiscoverycasePostTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostTagsResponse> SecurityEDiscoverycasePostTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycasePostTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycasePostTagsParameter, SecurityEDiscoverycasePostTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostTagsResponse> SecurityEDiscoverycasePostTagsAsync(SecurityEDiscoverycasePostTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycasePostTagsParameter, SecurityEDiscoverycasePostTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-post-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycasePostTagsResponse> SecurityEDiscoverycasePostTagsAsync(SecurityEDiscoverycasePostTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycasePostTagsParameter, SecurityEDiscoverycasePostTagsResponse>(parameter, cancellationToken);
        }
    }
}
