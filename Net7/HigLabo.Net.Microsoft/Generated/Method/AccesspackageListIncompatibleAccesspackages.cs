using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageListIncompatibleAccesspackagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages/{Id}/incompatibleAccessPackages";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CreatedDateTime,
            Description,
            DisplayName,
            Id,
            IsHidden,
            ModifiedDateTime,
            AccessPackagesIncompatibleWith,
            AssignmentPolicies,
            Catalog,
            IncompatibleAccessPackages,
            IncompatibleGroups,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AccessPackages_Id_IncompatibleAccessPackages,
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
    public partial class AccesspackageListIncompatibleAccesspackagesResponse : RestApiResponse
    {
        public AccessPackage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListIncompatibleAccesspackagesResponse> AccesspackageListIncompatibleAccesspackagesAsync()
        {
            var p = new AccesspackageListIncompatibleAccesspackagesParameter();
            return await this.SendAsync<AccesspackageListIncompatibleAccesspackagesParameter, AccesspackageListIncompatibleAccesspackagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListIncompatibleAccesspackagesResponse> AccesspackageListIncompatibleAccesspackagesAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageListIncompatibleAccesspackagesParameter();
            return await this.SendAsync<AccesspackageListIncompatibleAccesspackagesParameter, AccesspackageListIncompatibleAccesspackagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListIncompatibleAccesspackagesResponse> AccesspackageListIncompatibleAccesspackagesAsync(AccesspackageListIncompatibleAccesspackagesParameter parameter)
        {
            return await this.SendAsync<AccesspackageListIncompatibleAccesspackagesParameter, AccesspackageListIncompatibleAccesspackagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackage-list-incompatibleaccesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageListIncompatibleAccesspackagesResponse> AccesspackageListIncompatibleAccesspackagesAsync(AccesspackageListIncompatibleAccesspackagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageListIncompatibleAccesspackagesParameter, AccesspackageListIncompatibleAccesspackagesResponse>(parameter, cancellationToken);
        }
    }
}
