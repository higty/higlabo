using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoverycaseListTagsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            ChildSelectability,
            CreatedBy,
            Description,
            DisplayName,
            Id,
            LastModifiedDateTime,
            ChildTags,
            Parent,
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
    }
    public partial class SecurityEdiscoverycaseListTagsResponse : RestApiResponse
    {
        public EdiscoveryReviewTag[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListTagsResponse> SecurityEdiscoverycaseListTagsAsync()
        {
            var p = new SecurityEdiscoverycaseListTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListTagsParameter, SecurityEdiscoverycaseListTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListTagsResponse> SecurityEdiscoverycaseListTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoverycaseListTagsParameter();
            return await this.SendAsync<SecurityEdiscoverycaseListTagsParameter, SecurityEdiscoverycaseListTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListTagsResponse> SecurityEdiscoverycaseListTagsAsync(SecurityEdiscoverycaseListTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListTagsParameter, SecurityEdiscoverycaseListTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoverycaseListTagsResponse> SecurityEdiscoverycaseListTagsAsync(SecurityEdiscoverycaseListTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoverycaseListTagsParameter, SecurityEdiscoverycaseListTagsResponse>(parameter, cancellationToken);
        }
    }
}
