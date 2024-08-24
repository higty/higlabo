using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreTermListRelationsParameter : IRestApiParameter, IQueryParameterProperty
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
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Relations: return $"/sites/{SiteId}/termStore/sets/{SetId}/relations";
                    case ApiPath.Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations: return $"/sites/{SiteId}/termStore/sets/{SetId}/terms/{TermId}/relations";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_TermStore_Sets_SetId_Relations,
            Sites_SiteId_TermStore_Sets_SetId_Terms_TermId_Relations,
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
    public partial class TermStoreTermListRelationsResponse : RestApiResponse<TermStoreRelation>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync()
        {
            var p = new TermStoreTermListRelationsParameter();
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreTermListRelationsParameter();
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(TermStoreTermListRelationsParameter parameter)
        {
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreTermListRelationsResponse> TermStoreTermListRelationsAsync(TermStoreTermListRelationsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-term-list-relations?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TermStoreRelation> TermStoreTermListRelationsEnumerateAsync(TermStoreTermListRelationsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TermStoreTermListRelationsParameter, TermStoreTermListRelationsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TermStoreRelation>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
