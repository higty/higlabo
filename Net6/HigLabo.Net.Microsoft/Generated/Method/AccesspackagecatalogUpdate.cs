using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackagecatalogUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageCatalogId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Catalogs_AccessPackageCatalogId: return $"/identityGovernance/entitlementManagement/catalogs/{AccessPackageCatalogId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum AccesspackagecatalogUpdateParameterAccessPackageCatalogType
        {
            UserManaged,
            ServiceDefault,
            ServiceManaged,
            UnknownFutureValue,
        }
        public enum AccesspackagecatalogUpdateParameterAccessPackageCatalogState
        {
            Published,
            Unpublished,
            UnknownFutureValue,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Catalogs_AccessPackageCatalogId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? DisplayName { get; set; }
        public string? Description { get; set; }
        public AccesspackagecatalogUpdateParameterAccessPackageCatalogType CatalogType { get; set; }
        public AccesspackagecatalogUpdateParameterAccessPackageCatalogState State { get; set; }
        public bool? IsExternallyVisible { get; set; }
    }
    public partial class AccesspackagecatalogUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogUpdateResponse> AccesspackagecatalogUpdateAsync()
        {
            var p = new AccesspackagecatalogUpdateParameter();
            return await this.SendAsync<AccesspackagecatalogUpdateParameter, AccesspackagecatalogUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogUpdateResponse> AccesspackagecatalogUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagecatalogUpdateParameter();
            return await this.SendAsync<AccesspackagecatalogUpdateParameter, AccesspackagecatalogUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogUpdateResponse> AccesspackagecatalogUpdateAsync(AccesspackagecatalogUpdateParameter parameter)
        {
            return await this.SendAsync<AccesspackagecatalogUpdateParameter, AccesspackagecatalogUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogUpdateResponse> AccesspackagecatalogUpdateAsync(AccesspackagecatalogUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagecatalogUpdateParameter, AccesspackagecatalogUpdateResponse>(parameter, cancellationToken);
        }
    }
}
