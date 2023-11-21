using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAccesspackagesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AccessPackages: return $"/identityGovernance/entitlementManagement/accessPackages";
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
            IdentityGovernance_EntitlementManagement_AccessPackages,
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
    public partial class EntitlementManagementListAccesspackagesResponse : RestApiResponse
    {
        public AccessPackage[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAccesspackagesResponse> EntitlementManagementListAccesspackagesAsync()
        {
            var p = new EntitlementManagementListAccesspackagesParameter();
            return await this.SendAsync<EntitlementManagementListAccesspackagesParameter, EntitlementManagementListAccesspackagesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAccesspackagesResponse> EntitlementManagementListAccesspackagesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAccesspackagesParameter();
            return await this.SendAsync<EntitlementManagementListAccesspackagesParameter, EntitlementManagementListAccesspackagesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAccesspackagesResponse> EntitlementManagementListAccesspackagesAsync(EntitlementManagementListAccesspackagesParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAccesspackagesParameter, EntitlementManagementListAccesspackagesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-accesspackages?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<EntitlementManagementListAccesspackagesResponse> EntitlementManagementListAccesspackagesAsync(EntitlementManagementListAccesspackagesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAccesspackagesParameter, EntitlementManagementListAccesspackagesResponse>(parameter, cancellationToken);
        }
    }
}
