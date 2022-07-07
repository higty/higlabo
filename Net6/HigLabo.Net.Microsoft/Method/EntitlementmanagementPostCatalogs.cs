using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementPostCatalogsParameter : IRestApiParameter
    {
        public enum EntitlementmanagementPostCatalogsParameterAccessPackageCatalogState
        {
            Published,
            Unpublished,
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
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public EntitlementmanagementPostCatalogsParameterAccessPackageCatalogState State { get; set; }
        public bool? IsExternallyVisible { get; set; }
    }
    public partial class EntitlementmanagementPostCatalogsResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostCatalogsResponse> EntitlementmanagementPostCatalogsAsync()
        {
            var p = new EntitlementmanagementPostCatalogsParameter();
            return await this.SendAsync<EntitlementmanagementPostCatalogsParameter, EntitlementmanagementPostCatalogsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostCatalogsResponse> EntitlementmanagementPostCatalogsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementPostCatalogsParameter();
            return await this.SendAsync<EntitlementmanagementPostCatalogsParameter, EntitlementmanagementPostCatalogsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostCatalogsResponse> EntitlementmanagementPostCatalogsAsync(EntitlementmanagementPostCatalogsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementPostCatalogsParameter, EntitlementmanagementPostCatalogsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementPostCatalogsResponse> EntitlementmanagementPostCatalogsAsync(EntitlementmanagementPostCatalogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementPostCatalogsParameter, EntitlementmanagementPostCatalogsResponse>(parameter, cancellationToken);
        }
    }
}
