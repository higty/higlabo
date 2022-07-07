using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentpolicyDeleteParameter : IRestApiParameter
    {
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
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AccessPackageAssignmentPolicyId { get; set; }
    }
    public partial class AccesspackageassignmentpolicyDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyDeleteResponse> AccesspackageassignmentpolicyDeleteAsync()
        {
            var p = new AccesspackageassignmentpolicyDeleteParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyDeleteParameter, AccesspackageassignmentpolicyDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyDeleteResponse> AccesspackageassignmentpolicyDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentpolicyDeleteParameter();
            return await this.SendAsync<AccesspackageassignmentpolicyDeleteParameter, AccesspackageassignmentpolicyDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyDeleteResponse> AccesspackageassignmentpolicyDeleteAsync(AccesspackageassignmentpolicyDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyDeleteParameter, AccesspackageassignmentpolicyDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentpolicy-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentpolicyDeleteResponse> AccesspackageassignmentpolicyDeleteAsync(AccesspackageassignmentpolicyDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentpolicyDeleteParameter, AccesspackageassignmentpolicyDeleteResponse>(parameter, cancellationToken);
        }
    }
}
