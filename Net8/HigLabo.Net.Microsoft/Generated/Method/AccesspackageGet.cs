using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
    /// </summary>
    public partial class AccessPackageGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId: return $"/identityGovernance/entitlementManagement/accessPackages/{AccessPackageId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_AccessPackageId,
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
    public partial class AccessPackageGetResponse : RestApiResponse
    {
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? Description { get; set; }
        public string? DisplayName { get; set; }
        public string? Id { get; set; }
        public bool? IsHidden { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public AccessPackage[]? AccessPackagesIncompatibleWith { get; set; }
        public AccessPackageAssignmentPolicy[]? AssignmentPolicies { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
        public AccessPackage[]? IncompatibleAccessPackages { get; set; }
        public Group[]? IncompatibleGroups { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageGetResponse> AccessPackageGetAsync()
        {
            var p = new AccessPackageGetParameter();
            return await this.SendAsync<AccessPackageGetParameter, AccessPackageGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageGetResponse> AccessPackageGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccessPackageGetParameter();
            return await this.SendAsync<AccessPackageGetParameter, AccessPackageGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageGetResponse> AccessPackageGetAsync(AccessPackageGetParameter parameter)
        {
            return await this.SendAsync<AccessPackageGetParameter, AccessPackageGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccessPackageGetResponse> AccessPackageGetAsync(AccessPackageGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccessPackageGetParameter, AccessPackageGetResponse>(parameter, cancellationToken);
        }
    }
}
