using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackagecatalogDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Catalogs_AccessPackageCatalogId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Catalogs_AccessPackageCatalogId: return $"/identityGovernance/entitlementManagement/catalogs/{AccessPackageCatalogId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AccessPackageCatalogId { get; set; }
    }
    public partial class AccesspackagecatalogDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync()
        {
            var p = new AccesspackagecatalogDeleteParameter();
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagecatalogDeleteParameter();
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(AccesspackagecatalogDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogDeleteResponse> AccesspackagecatalogDeleteAsync(AccesspackagecatalogDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagecatalogDeleteParameter, AccesspackagecatalogDeleteResponse>(parameter, cancellationToken);
        }
    }
}
