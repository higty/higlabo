using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTermListChildrenParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }
            public string? SetId { get; set; }
            public string? TermId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Children: return $"/sites/{SiteId}/termStore/sets/{SetId}/children";
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/children";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_TermStore_Sets_SetId_Children,
            Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Children,
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
    public partial class TermStoreTermListChildrenResponse : RestApiResponse<TermStoreTerm>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync()
        {
            var p = new TermStoreTermListChildrenParameter();
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermListChildrenParameter();
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(TermStoreTermListChildrenParameter parameter)
        {
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListChildrenResponse> TermStoreTermListChildrenAsync(TermStoreTermListChildrenParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-children?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TermStoreTerm> TermStoreTermListChildrenEnumerateAsync(TermStoreTermListChildrenParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TermStoreTermListChildrenParameter, TermStoreTermListChildrenResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TermStoreTerm>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
