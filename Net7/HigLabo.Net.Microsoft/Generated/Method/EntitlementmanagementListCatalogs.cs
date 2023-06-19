using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListCatalogsParameter : IRestApiParameter, IQueryParameterProperty
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

        public enum Field
        {
            CatalogType,
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IsExternallyVisible,
            ModifiedDateTime,
            State,
            AccessPackages,
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
    public partial class EntitlementManagementListCatalogsResponse : RestApiResponse
    {
        public AccessPackageCatalog[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListCatalogsResponse> EntitlementManagementListCatalogsAsync()
        {
            var p = new EntitlementManagementListCatalogsParameter();
            return await this.SendAsync<EntitlementManagementListCatalogsParameter, EntitlementManagementListCatalogsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListCatalogsResponse> EntitlementManagementListCatalogsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListCatalogsParameter();
            return await this.SendAsync<EntitlementManagementListCatalogsParameter, EntitlementManagementListCatalogsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListCatalogsResponse> EntitlementManagementListCatalogsAsync(EntitlementManagementListCatalogsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListCatalogsParameter, EntitlementManagementListCatalogsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-catalogs?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListCatalogsResponse> EntitlementManagementListCatalogsAsync(EntitlementManagementListCatalogsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListCatalogsParameter, EntitlementManagementListCatalogsResponse>(parameter, cancellationToken);
        }
    }
}
