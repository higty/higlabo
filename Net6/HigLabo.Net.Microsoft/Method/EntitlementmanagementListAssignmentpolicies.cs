using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListAssignmentpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies: return $"/identityGovernance/entitlementManagement/assignmentPolicies";
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
    }
    public partial class EntitlementmanagementListAssignmentpoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentpolicy?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackageAssignmentPolicy
        {
            public enum AccessPackageAssignmentPolicyAllowedTargetScope
            {
                NotSpecified,
                SpecificDirectoryUsers,
                SpecificConnectedOrganizationUsers,
                SpecificDirectoryServicePrincipals,
                AllMemberUsers,
                AllDirectoryUsers,
                AllDirectoryServicePrincipals,
                AllConfiguredConnectedOrganizationUsers,
                AllExternalUsers,
                UnknownFutureValue,
            }

            public AccessPackageAssignmentPolicyAllowedTargetScope AllowedTargetScope { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Description { get; set; }
            public string? DisplayName { get; set; }
            public ExpirationPattern? Expiration { get; set; }
            public string? Id { get; set; }
            public DateTimeOffset? ModifiedDateTime { get; set; }
            public AccessPackageAssignmentApprovalSettings? RequestApprovalSettings { get; set; }
            public AccessPackageAssignmentRequestorSettings? RequestorSettings { get; set; }
            public AccessPackageAssignmentReviewSettings? ReviewSettings { get; set; }
            public SubjectSet[]? SpecificAllowedTargets { get; set; }
        }

        public AccessPackageAssignmentPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentpoliciesResponse> EntitlementmanagementListAssignmentpoliciesAsync()
        {
            var p = new EntitlementmanagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentpoliciesParameter, EntitlementmanagementListAssignmentpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentpoliciesResponse> EntitlementmanagementListAssignmentpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListAssignmentpoliciesParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentpoliciesParameter, EntitlementmanagementListAssignmentpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentpoliciesResponse> EntitlementmanagementListAssignmentpoliciesAsync(EntitlementmanagementListAssignmentpoliciesParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentpoliciesParameter, EntitlementmanagementListAssignmentpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentpoliciesResponse> EntitlementmanagementListAssignmentpoliciesAsync(EntitlementmanagementListAssignmentpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentpoliciesParameter, EntitlementmanagementListAssignmentpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
