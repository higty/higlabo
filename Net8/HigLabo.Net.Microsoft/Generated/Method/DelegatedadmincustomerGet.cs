using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadmincustomerGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminCustomerId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminCustomers_DelegatedAdminCustomerId: return $"/tenantRelationships/delegatedAdminCustomers/{DelegatedAdminCustomerId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminCustomers_DelegatedAdminCustomerId,
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
    public partial class DelegatedadmincustomerGetResponse : RestApiResponse
    {
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public string? TenantId { get; set; }
        public DelegatedAdminServiceManagementDetail[]? ServiceManagementDetails { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerGetResponse> DelegatedadmincustomerGetAsync()
        {
            var p = new DelegatedadmincustomerGetParameter();
            return await this.SendAsync<DelegatedadmincustomerGetParameter, DelegatedadmincustomerGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerGetResponse> DelegatedadmincustomerGetAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadmincustomerGetParameter();
            return await this.SendAsync<DelegatedadmincustomerGetParameter, DelegatedadmincustomerGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerGetResponse> DelegatedadmincustomerGetAsync(DelegatedadmincustomerGetParameter parameter)
        {
            return await this.SendAsync<DelegatedadmincustomerGetParameter, DelegatedadmincustomerGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerGetResponse> DelegatedadmincustomerGetAsync(DelegatedadmincustomerGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadmincustomerGetParameter, DelegatedadmincustomerGetResponse>(parameter, cancellationToken);
        }
    }
}
