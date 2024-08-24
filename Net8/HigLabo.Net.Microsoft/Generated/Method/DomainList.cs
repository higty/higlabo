using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
    /// </summary>
    public partial class DomainListParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Domains: return $"/domains";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            Domains,
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
    public partial class DomainListResponse : RestApiResponse<Domain>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DomainListResponse> DomainListAsync()
        {
            var p = new DomainListParameter();
            return await this.SendAsync<DomainListParameter, DomainListResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DomainListResponse> DomainListAsync(CancellationToken cancellationToken)
        {
            var p = new DomainListParameter();
            return await this.SendAsync<DomainListParameter, DomainListResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DomainListResponse> DomainListAsync(DomainListParameter parameter)
        {
            return await this.SendAsync<DomainListParameter, DomainListResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DomainListResponse> DomainListAsync(DomainListParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DomainListParameter, DomainListResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/domain-list?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<Domain> DomainListEnumerateAsync(DomainListParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DomainListParameter, DomainListResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<Domain>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
