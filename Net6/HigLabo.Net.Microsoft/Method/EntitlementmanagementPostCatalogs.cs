using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementManagementPostCatalogsParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Catalogs: return $"/identityGovernance/entitlementManagement/catalogs";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum EntitlementManagementPostCatalogsParameterAccessPackageCatalogState
        {
            Published,
            Unpublished,
        }
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
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Catalogs,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public EntitlementManagementPostCatalogsParameterAccessPackageCatalogState State { get; set; }
        public bool? IsExternallyVisible { get; set; }
        public AccessPackageCatalogAccessPackageCatalogType CatalogType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackage[]? AccessPackages { get; set; }
    }
    public partial class EntitlementManagementPostCatalogsResponse : RestApiResponse
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
        public AccessPackage[]? AccessPackages { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostCatalogsResponse> EntitlementManagementPostCatalogsAsync()
        {
            var p = new EntitlementManagementPostCatalogsParameter();
            return await this.SendAsync<EntitlementManagementPostCatalogsParameter, EntitlementManagementPostCatalogsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostCatalogsResponse> EntitlementManagementPostCatalogsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementPostCatalogsParameter();
            return await this.SendAsync<EntitlementManagementPostCatalogsParameter, EntitlementManagementPostCatalogsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostCatalogsResponse> EntitlementManagementPostCatalogsAsync(EntitlementManagementPostCatalogsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementPostCatalogsParameter, EntitlementManagementPostCatalogsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-post-catalogs?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementPostCatalogsResponse> EntitlementManagementPostCatalogsAsync(EntitlementManagementPostCatalogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementPostCatalogsParameter, EntitlementManagementPostCatalogsResponse>(parameter, cancellationToken);
        }
    }
}
