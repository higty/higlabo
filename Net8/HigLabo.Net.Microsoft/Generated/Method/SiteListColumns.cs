using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
    /// </summary>
    public partial class SiteListColumnsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? SiteId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Sites_SiteId_Columns: return $"/sites/{SiteId}/columns";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Sites_SiteId_Columns,
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
    public partial class SiteListColumnsResponse : RestApiResponse<ColumnDefinition>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListColumnsResponse> SiteListColumnsAsync()
        {
            var p = new SiteListColumnsParameter();
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListColumnsResponse> SiteListColumnsAsync(CancellationToken cancellationToken)
        {
            var p = new SiteListColumnsParameter();
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListColumnsResponse> SiteListColumnsAsync(SiteListColumnsParameter parameter)
        {
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<SiteListColumnsResponse> SiteListColumnsAsync(SiteListColumnsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/site-list-columns?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<ColumnDefinition> SiteListColumnsEnumerateAsync(SiteListColumnsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<SiteListColumnsParameter, SiteListColumnsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<ColumnDefinition>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
