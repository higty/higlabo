using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListCatalogsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Catalogs,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Catalogs: return $"/identityGovernance/entitlementManagement/catalogs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
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
    public partial class EntitlementmanagementListCatalogsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackagecatalog?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackageCatalog
        {
            public enum AccessPackageCatalogAccessPackageCatalogType
            {
                UserManaged,
                ServiceDefault,
                ServiceManaged,
                UnknownFutureValue,
            }
            public enum AccessPackageCatalogAccessPackageCatalogState
            {
                Published,
                Unpublished,
                UnknownFutureValue,
            }

            public AccessPackageCatalogAccessPackageCatalogType CatalogType { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public string? Id { get; set; }
            public bool? IsExternallyVisible { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
            public AccessPackageCatalogAccessPackageCatalogState State { get; set; }
        }

        public AccessPackageCatalog[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListCatalogsResponse> EntitlementmanagementListCatalogsAsync()
        {
            var p = new EntitlementmanagementListCatalogsParameter();
            return await this.SendAsync<EntitlementmanagementListCatalogsParameter, EntitlementmanagementListCatalogsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListCatalogsResponse> EntitlementmanagementListCatalogsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListCatalogsParameter();
            return await this.SendAsync<EntitlementmanagementListCatalogsParameter, EntitlementmanagementListCatalogsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListCatalogsResponse> EntitlementmanagementListCatalogsAsync(EntitlementmanagementListCatalogsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListCatalogsParameter, EntitlementmanagementListCatalogsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListCatalogsResponse> EntitlementmanagementListCatalogsAsync(EntitlementmanagementListCatalogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListCatalogsParameter, EntitlementmanagementListCatalogsResponse>(parameter, cancellationToken);
        }
    }
}
