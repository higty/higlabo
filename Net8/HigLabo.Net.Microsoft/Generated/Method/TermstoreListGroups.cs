using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
    /// </summary>
    public partial class TermStoreListGroupsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_TermStore_Groups: return $"/sites/{SiteId}/termStore/groups";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_TermStore_Groups,
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
    public partial class TermStoreListGroupsResponse : RestApiResponse<TermStoreGroup>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreListGroupsResponse> TermStoreListGroupsAsync()
        {
            var p = new TermStoreListGroupsParameter();
            return await this.SendAsync<TermStoreListGroupsParameter, TermStoreListGroupsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreListGroupsResponse> TermStoreListGroupsAsync(CancellationToken cancellationToken)
        {
            var p = new TermStoreListGroupsParameter();
            return await this.SendAsync<TermStoreListGroupsParameter, TermStoreListGroupsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreListGroupsResponse> TermStoreListGroupsAsync(TermStoreListGroupsParameter parameter)
        {
            return await this.SendAsync<TermStoreListGroupsParameter, TermStoreListGroupsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TermStoreListGroupsResponse> TermStoreListGroupsAsync(TermStoreListGroupsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TermStoreListGroupsParameter, TermStoreListGroupsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/termstore-list-groups?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<TermStoreGroup> TermStoreListGroupsEnumerateAsync(TermStoreListGroupsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TermStoreListGroupsParameter, TermStoreListGroupsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<TermStoreGroup>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
