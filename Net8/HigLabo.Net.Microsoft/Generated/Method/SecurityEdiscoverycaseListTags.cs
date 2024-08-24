using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
    /// </summary>
    public partial class SecurityEDiscoverycaseListTagsParameter : IRestApiParameter, IQueryParameterProperty
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
    public partial class SecurityEDiscoverycaseListTagsResponse : RestApiResponse<EDiscoveryReviewTag>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListTagsResponse> SecurityEDiscoverycaseListTagsAsync()
        {
            var p = new SecurityEDiscoverycaseListTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListTagsParameter, SecurityEDiscoverycaseListTagsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListTagsResponse> SecurityEDiscoverycaseListTagsAsync(CancellationToken cancellationToken)
        {
            var p = new SecurityEDiscoverycaseListTagsParameter();
            return await this.SendAsync<SecurityEDiscoverycaseListTagsParameter, SecurityEDiscoverycaseListTagsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListTagsResponse> SecurityEDiscoverycaseListTagsAsync(SecurityEDiscoverycaseListTagsParameter parameter)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListTagsParameter, SecurityEDiscoverycaseListTagsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SecurityEDiscoverycaseListTagsResponse> SecurityEDiscoverycaseListTagsAsync(SecurityEDiscoverycaseListTagsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SecurityEDiscoverycaseListTagsParameter, SecurityEDiscoverycaseListTagsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/security-ediscoverycase-list-tags?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<EDiscoveryReviewTag> SecurityEDiscoverycaseListTagsEnumerateAsync(SecurityEDiscoverycaseListTagsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SecurityEDiscoverycaseListTagsParameter, SecurityEDiscoverycaseListTagsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<EDiscoveryReviewTag>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
