using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentPolicyGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentPolicyId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId: return $"/identityGovernance/entitlementManagement/assignmentPolicies/{AccessPackageAssignmentPolicyId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentPolicies_AccessPackageAssignmentPolicyId,
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
    public partial class AccesspackageAssignmentPolicyGetResponse : RestApiResponse
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
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageCatalog? Catalog { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyGetResponse> AccesspackageAssignmentPolicyGetAsync()
        {
            var p = new AccesspackageAssignmentPolicyGetParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyGetParameter, AccesspackageAssignmentPolicyGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyGetResponse> AccesspackageAssignmentPolicyGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentPolicyGetParameter();
            return await this.SendAsync<AccesspackageAssignmentPolicyGetParameter, AccesspackageAssignmentPolicyGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyGetResponse> AccesspackageAssignmentPolicyGetAsync(AccesspackageAssignmentPolicyGetParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyGetParameter, AccesspackageAssignmentPolicyGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentPolicyGetResponse> AccesspackageAssignmentPolicyGetAsync(AccesspackageAssignmentPolicyGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentPolicyGetParameter, AccesspackageAssignmentPolicyGetResponse>(parameter, cancellationToken);
        }
    }
}
