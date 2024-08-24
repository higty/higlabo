using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageCatalogDeleteParameter : IRestApiParameter
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
    }
    public partial class AccessPackageCatalogDeleteResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogDeleteResponse> AccessPackageCatalogDeleteAsync()
        {
            var p = new AccessPackageCatalogDeleteParameter();
            return await this.SendAsync<AccessPackageCatalogDeleteParameter, AccessPackageCatalogDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogDeleteResponse> AccessPackageCatalogDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageCatalogDeleteParameter();
            return await this.SendAsync<AccessPackageCatalogDeleteParameter, AccessPackageCatalogDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogDeleteResponse> AccessPackageCatalogDeleteAsync(AccessPackageCatalogDeleteParameter parameter)
        {
            return await this.SendAsync<AccessPackageCatalogDeleteParameter, AccessPackageCatalogDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageCatalogDeleteResponse> AccessPackageCatalogDeleteAsync(AccessPackageCatalogDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageCatalogDeleteParameter, AccessPackageCatalogDeleteResponse>(parameter, cancellationToken);
        }
    }
}
