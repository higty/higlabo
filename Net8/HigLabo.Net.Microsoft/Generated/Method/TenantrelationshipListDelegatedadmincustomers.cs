using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
    /// </summary>
    public partial class TenantrelationshipListDelegatedadminCustomersParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminCustomers: return $"/tenantRelationships/delegatedAdminCustomers";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminCustomers,
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
    public partial class TenantrelationshipListDelegatedadminCustomersResponse : RestApiResponse<DelegatedAdminCustomer>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminCustomersResponse> TenantrelationshipListDelegatedadminCustomersAsync()
        {
            var p = new TenantrelationshipListDelegatedadminCustomersParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadminCustomersParameter, TenantrelationshipListDelegatedadminCustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminCustomersResponse> TenantrelationshipListDelegatedadminCustomersAsync(CancellationToken cancellationToken)
        {
            var p = new TenantrelationshipListDelegatedadminCustomersParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadminCustomersParameter, TenantrelationshipListDelegatedadminCustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminCustomersResponse> TenantrelationshipListDelegatedadminCustomersAsync(TenantrelationshipListDelegatedadminCustomersParameter parameter)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadminCustomersParameter, TenantrelationshipListDelegatedadminCustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<TenantrelationshipListDelegatedadminCustomersResponse> TenantrelationshipListDelegatedadminCustomersAsync(TenantrelationshipListDelegatedadminCustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadminCustomersParameter, TenantrelationshipListDelegatedadminCustomersResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DelegatedAdminCustomer> TenantrelationshipListDelegatedadminCustomersEnumerateAsync(TenantrelationshipListDelegatedadminCustomersParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<TenantrelationshipListDelegatedadminCustomersParameter, TenantrelationshipListDelegatedadminCustomersResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DelegatedAdminCustomer>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
