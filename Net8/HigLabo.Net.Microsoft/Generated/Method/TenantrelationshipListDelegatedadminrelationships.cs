using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
    /// </summary>
    public partial class TenantrelationshipListDelegatedadminrelationshipsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminRelationships: return $"/tenantRelationships/delegatedAdminRelationships";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminRelationships,
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
    public partial class TenantrelationshipListDelegatedadminrelationshipsResponse : RestApiResponse<DelegatedAdminRelationship>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminrelationshipsResponse> TenantrelationshipListDelegatedadminrelationshipsAsync()
        {
            var p = new TenantrelationshipListDelegatedadminrelationshipsParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadminrelationshipsParameter, TenantrelationshipListDelegatedadminrelationshipsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminrelationshipsResponse> TenantrelationshipListDelegatedadminrelationshipsAsync(CancellationToken cancellationToken)
        {
            var p = new TenantrelationshipListDelegatedadminrelationshipsParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadminrelationshipsParameter, TenantrelationshipListDelegatedadminrelationshipsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminrelationshipsResponse> TenantrelationshipListDelegatedadminrelationshipsAsync(TenantrelationshipListDelegatedadminrelationshipsParameter parameter)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadminrelationshipsParameter, TenantrelationshipListDelegatedadminrelationshipsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminrelationshipsResponse> TenantrelationshipListDelegatedadminrelationshipsAsync(TenantrelationshipListDelegatedadminrelationshipsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadminrelationshipsParameter, TenantrelationshipListDelegatedadminrelationshipsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadminrelationships?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DelegatedAdminRelationship> TenantrelationshipListDelegatedadminrelationshipsEnumerateAsync(TenantrelationshipListDelegatedadminrelationshipsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TenantrelationshipListDelegatedadminrelationshipsParameter, TenantrelationshipListDelegatedadminrelationshipsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DelegatedAdminRelationship>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
