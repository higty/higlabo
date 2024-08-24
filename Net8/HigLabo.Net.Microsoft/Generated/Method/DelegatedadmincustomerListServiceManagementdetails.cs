using HigLabo.Net.OAuth;
using System.Runtime.CompilerServices;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadminCustomerListServiceManagementdetailsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? DelegatedAdminCustomerId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.TenantRelationships_DelegatedAdminCustomers_DelegatedAdminCustomerId_ServiceManagementDetails: return $"/tenantRelationships/delegatedAdminCustomers/{DelegatedAdminCustomerId}/serviceManagementDetails";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            TenantRelationships_DelegatedAdminCustomers_DelegatedAdminCustomerId_ServiceManagementDetails,
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
    public partial class DelegatedadminCustomerListServiceManagementdetailsResponse : RestApiResponse<DelegatedAdminServiceManagementDetail>
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminCustomerListServiceManagementdetailsResponse> DelegatedadminCustomerListServiceManagementdetailsAsync()
        {
            var p = new DelegatedadminCustomerListServiceManagementdetailsParameter();
            return await this.SendAsync<DelegatedadminCustomerListServiceManagementdetailsParameter, DelegatedadminCustomerListServiceManagementdetailsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminCustomerListServiceManagementdetailsResponse> DelegatedadminCustomerListServiceManagementdetailsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadminCustomerListServiceManagementdetailsParameter();
            return await this.SendAsync<DelegatedadminCustomerListServiceManagementdetailsParameter, DelegatedadminCustomerListServiceManagementdetailsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminCustomerListServiceManagementdetailsResponse> DelegatedadminCustomerListServiceManagementdetailsAsync(DelegatedadminCustomerListServiceManagementdetailsParameter parameter)
        {
            return await this.SendAsync<DelegatedadminCustomerListServiceManagementdetailsParameter, DelegatedadminCustomerListServiceManagementdetailsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadminCustomerListServiceManagementdetailsResponse> DelegatedadminCustomerListServiceManagementdetailsAsync(DelegatedadminCustomerListServiceManagementdetailsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadminCustomerListServiceManagementdetailsParameter, DelegatedadminCustomerListServiceManagementdetailsResponse>(parameter, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async IAsyncEnumerable<DelegatedAdminServiceManagementDetail> DelegatedadminCustomerListServiceManagementdetailsEnumerateAsync(DelegatedadminCustomerListServiceManagementdetailsParameter parameter, [EnumeratorCancellation] CancellationToken cancellationToken)
        {
            var res = await this.SendAsync<DelegatedadminCustomerListServiceManagementdetailsParameter, DelegatedadminCustomerListServiceManagementdetailsResponse>(parameter, cancellationToken);
            if (res.Value != null)
            {
                foreach (var item in res.Value)
                {
                    yield return item;
                }
                if (res.ODataNextLink.HasValue())
                {
                    await foreach (var item in this.GetValueListAsync<DelegatedAdminServiceManagementDetail>(res.ODataNextLink, cancellationToken))
                    {
                        yield return item;
                    }
                }
            }
        }
    }
}
