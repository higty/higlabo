using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEdiscoveryreviewtagAshierarchyParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? EdiscoveryCaseId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_AsHierarchy: return $"/security/cases/ediscoveryCases/{EdiscoveryCaseId}/tags/asHierarchy";
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
            Security_Cases_EdiscoveryCases_EdiscoveryCaseId_Tags_AsHierarchy,
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
    public partial class SecurityEdiscoveryreviewtagAshierarchyResponse : RestApiResponse
    {
        public EdiscoveryReviewTag[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewtagAshierarchyResponse> SecurityEdiscoveryreviewtagAshierarchyAsync()
        {
            var p = new SecurityEdiscoveryreviewtagAshierarchyParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewtagAshierarchyParameter, SecurityEdiscoveryreviewtagAshierarchyResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewtagAshierarchyResponse> SecurityEdiscoveryreviewtagAshierarchyAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEdiscoveryreviewtagAshierarchyParameter();
            return await this.SendAsync<SecurityEdiscoveryreviewtagAshierarchyParameter, SecurityEdiscoveryreviewtagAshierarchyResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewtagAshierarchyResponse> SecurityEdiscoveryreviewtagAshierarchyAsync(SecurityEdiscoveryreviewtagAshierarchyParameter parameter)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewtagAshierarchyParameter, SecurityEdiscoveryreviewtagAshierarchyResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoveryreviewtag-ashierarchy?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEdiscoveryreviewtagAshierarchyResponse> SecurityEdiscoveryreviewtagAshierarchyAsync(SecurityEdiscoveryreviewtagAshierarchyParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEdiscoveryreviewtagAshierarchyParameter, SecurityEdiscoveryreviewtagAshierarchyResponse>(parameter, cancellationToken);
        }
    }
}
