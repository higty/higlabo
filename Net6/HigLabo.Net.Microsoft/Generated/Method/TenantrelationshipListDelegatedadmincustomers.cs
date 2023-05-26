using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
    /// </summary>
    public partial class TenantrelationshipListDelegatedadmincustomersParameter : IRestApiParameter, IQueryParameterProperty
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
            DisplayName,
            Id,
            TenantId,
            ServiceManagementDetails,
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
    public partial class TenantrelationshipListDelegatedadmincustomersResponse : RestApiResponse
    {
        public DelegatedAdminCustomer[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async Task<TenantrelationshipListDelegatedadmincustomersResponse> TenantrelationshipListDelegatedadmincustomersAsync()
        {
            var p = new TenantrelationshipListDelegatedadmincustomersParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadmincustomersParameter, TenantrelationshipListDelegatedadmincustomersResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async Task<TenantrelationshipListDelegatedadmincustomersResponse> TenantrelationshipListDelegatedadmincustomersAsync(CancellationToken cancellationToken)
        {
            var p = new TenantrelationshipListDelegatedadmincustomersParameter();
            return await this.SendAsync<TenantrelationshipListDelegatedadmincustomersParameter, TenantrelationshipListDelegatedadmincustomersResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async Task<TenantrelationshipListDelegatedadmincustomersResponse> TenantrelationshipListDelegatedadmincustomersAsync(TenantrelationshipListDelegatedadmincustomersParameter parameter)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadmincustomersParameter, TenantrelationshipListDelegatedadmincustomersResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/tenantrelationship-list-delegatedadmincustomers?view=graph-rest-1.0
        /// </summary>
        public async Task<TenantrelationshipListDelegatedadmincustomersResponse> TenantrelationshipListDelegatedadmincustomersAsync(TenantrelationshipListDelegatedadmincustomersParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<TenantrelationshipListDelegatedadmincustomersParameter, TenantrelationshipListDelegatedadmincustomersResponse>(parameter, cancellationToken);
        }
    }
}
