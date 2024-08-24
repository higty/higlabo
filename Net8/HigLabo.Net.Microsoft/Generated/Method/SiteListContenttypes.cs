using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class SiteListContentTypesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_ContentTypes: return $"/sites/{SiteId}/contentTypes";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_ContentTypes,
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
    public partial class SiteListContentTypesResponse : RestApiResponse<ContentType>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListContentTypesResponse> SiteListContentTypesAsync()
        {
            var p = new SiteListContentTypesParameter();
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListContentTypesResponse> SiteListContentTypesAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListContentTypesParameter();
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListContentTypesResponse> SiteListContentTypesAsync(SiteListContentTypesParameter parameter)
        {
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListContentTypesResponse> SiteListContentTypesAsync(SiteListContentTypesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-contenttypes?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ContentType> SiteListContentTypesEnumerateAsync(SiteListContentTypesParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SiteListContentTypesParameter, SiteListContentTypesResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ContentType>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
