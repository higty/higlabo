using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAssignmentpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies: return $"/identityGovernance/entitlementManagement/assignmentPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AllowedTargetScope,
            AutomaticRequestSettings,
            CreatedDateTime,
            Description,
            DisplayName,
            Expiration,
            Id,
            ModifiedDateTime,
            RequestApprovalSettings,
            RequestorSettings,
            ReviewSettings,
            SpecificAllowedTargets,
            AccessPackage,
            Catalog,
            Questions,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies,
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
    public partial class EntitlementManagementListAssignmentpoliciesResponse : RestApiResponse
    {
        public AccessPackageAssignmentPolicy[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync()
        {
            var p = new EntitlementManagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(EntitlementManagementListAssignmentpoliciesParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentpoliciesResponse> EntitlementManagementListAssignmentpoliciesAsync(EntitlementManagementListAssignmentpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentpoliciesParameter, EntitlementManagementListAssignmentpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
