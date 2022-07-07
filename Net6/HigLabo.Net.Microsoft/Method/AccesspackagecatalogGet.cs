using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackagecatalogGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string AccessPackageCatalogId { get; set; }
    }
    public partial class AccesspackagecatalogGetResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogGetResponse> AccesspackagecatalogGetAsync()
        {
            var p = new AccesspackagecatalogGetParameter();
            return await this.SendAsync<AccesspackagecatalogGetParameter, AccesspackagecatalogGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogGetResponse> AccesspackagecatalogGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackagecatalogGetParameter();
            return await this.SendAsync<AccesspackagecatalogGetParameter, AccesspackagecatalogGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogGetResponse> AccesspackagecatalogGetAsync(AccesspackagecatalogGetParameter parameter)
        {
            return await this.SendAsync<AccesspackagecatalogGetParameter, AccesspackagecatalogGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackagecatalog-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackagecatalogGetResponse> AccesspackagecatalogGetAsync(AccesspackagecatalogGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackagecatalogGetParameter, AccesspackagecatalogGetResponse>(parameter, cancellationToken);
        }
    }
}
