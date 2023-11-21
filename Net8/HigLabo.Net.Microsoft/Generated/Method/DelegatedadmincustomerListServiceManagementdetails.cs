using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
    /// </summary>
    public partial class DelegatedadmincustomerListServiceManagementdetailsParameter : IRestApiParameter, IQueryParameterProperty
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
            Id,
            ServiceName,
            ServiceManagementUrl,
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
    public partial class DelegatedadmincustomerListServiceManagementdetailsResponse : RestApiResponse
    {
        public DelegatedAdminServiceManagementDetail[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerListServiceManagementdetailsResponse> DelegatedadmincustomerListServiceManagementdetailsAsync()
        {
            var p = new DelegatedadmincustomerListServiceManagementdetailsParameter();
            return await this.SendAsync<DelegatedadmincustomerListServiceManagementdetailsParameter, DelegatedadmincustomerListServiceManagementdetailsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerListServiceManagementdetailsResponse> DelegatedadmincustomerListServiceManagementdetailsAsync(CancellationToken cancellationToken)
        {
            var p = new DelegatedadmincustomerListServiceManagementdetailsParameter();
            return await this.SendAsync<DelegatedadmincustomerListServiceManagementdetailsParameter, DelegatedadmincustomerListServiceManagementdetailsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerListServiceManagementdetailsResponse> DelegatedadmincustomerListServiceManagementdetailsAsync(DelegatedadmincustomerListServiceManagementdetailsParameter parameter)
        {
            return await this.SendAsync<DelegatedadmincustomerListServiceManagementdetailsParameter, DelegatedadmincustomerListServiceManagementdetailsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/delegatedadmincustomer-list-servicemanagementdetails?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<DelegatedadmincustomerListServiceManagementdetailsResponse> DelegatedadmincustomerListServiceManagementdetailsAsync(DelegatedadmincustomerListServiceManagementdetailsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<DelegatedadmincustomerListServiceManagementdetailsParameter, DelegatedadmincustomerListServiceManagementdetailsResponse>(parameter, cancellationToken);
        }
    }
}
