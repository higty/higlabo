using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageCatalogUpdateParameter : IRestApiParameter
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

        public enum AccessPackageCatalogUpdateParameterAccessPackageCatalogType
        {
            UserManaged,
            ServiceDefault,
            ServiceManaged,
            UnknownFutureValue,
        }
        public enum AccessPackageCatalogUpdateParameterAccessPackageCatalogState
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
        public AccessPackageCatalogUpdateParameterAccessPackageCatalogType CatalogType { get; set; }
        public AccessPackageCatalogUpdateParameterAccessPackageCatalogState State { get; set; }
        public bool? IsExternallyVisible { get; set; }
    }
    public partial class AccessPackageCatalogUpdateResponse : RestApiResponse
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
        public async ValueTask<AccessPackageCatalogUpdateResponse> AccessPackageCatalogUpdateAsync()
        {
            var p = new AccessPackageCatalogUpdateParameter();
            return await this.SendAsync<AccessPackageCatalogUpdateParameter, AccessPackageCatalogUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogUpdateResponse> AccessPackageCatalogUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageCatalogUpdateParameter();
            return await this.SendAsync<AccessPackageCatalogUpdateParameter, AccessPackageCatalogUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogUpdateResponse> AccessPackageCatalogUpdateAsync(AccessPackageCatalogUpdateParameter parameter)
        {
            return await this.SendAsync<AccessPackageCatalogUpdateParameter, AccessPackageCatalogUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-update?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogUpdateResponse> AccessPackageCatalogUpdateAsync(AccessPackageCatalogUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageCatalogUpdateParameter, AccessPackageCatalogUpdateResponse>(parameter, cancellationToken);
        }
    }
}
