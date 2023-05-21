using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackagecatalogDeleteParameter : IRestApiParameter
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
    public partial class AccesspackagecatalogDeleteResponse : RestApiResponse
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
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync()
        {
            var p = new AccesspackagecatalogDeleteParameter();
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagecatalogDeleteParameter();
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(AccesspackagecatalogDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(AccesspackagecatalogDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(parameter, cancellationToken);
        }
    }
}
