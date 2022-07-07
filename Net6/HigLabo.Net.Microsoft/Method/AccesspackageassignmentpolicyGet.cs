using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentpolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId: return $"/identityGovernance/entitlementManagement/assignmentPolicies/{AccessPackageAssignmentPolicyId}";
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
        public string AccessPackageAssignmentPolicyId { get; set; }
    }
    public partial class AccesspackageassignmentpolicyGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyGetResponse> AccesspackageassignmentpolicyGetAsync()
        {
            var p = new AccesspackageassignmentpolicyGetParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyGetParameter, AccesspackageassignmentpolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyGetResponse> AccesspackageassignmentpolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentpolicyGetParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyGetParameter, AccesspackageassignmentpolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyGetResponse> AccesspackageassignmentpolicyGetAsync(AccesspackageassignmentpolicyGetParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyGetParameter, AccesspackageassignmentpolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyGetResponse> AccesspackageassignmentpolicyGetAsync(AccesspackageassignmentpolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyGetParameter, AccesspackageassignmentpolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
