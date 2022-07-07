using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentrequestCancelParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId_Cancel: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}/cancel";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public string AccessPackageAssignmentRequestId { get; set; }
    }
    public partial class AccesspackageassignmentrequestCancelResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestCancelResponse> AccesspackageassignmentrequestCancelAsync()
        {
            var p = new AccesspackageassignmentrequestCancelParameter();
            return await this.SendAsync<AccesspackageassignmentrequestCancelParameter, AccesspackageassignmentrequestCancelResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestCancelResponse> AccesspackageassignmentrequestCancelAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentrequestCancelParameter();
            return await this.SendAsync<AccesspackageassignmentrequestCancelParameter, AccesspackageassignmentrequestCancelResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestCancelResponse> AccesspackageassignmentrequestCancelAsync(AccesspackageassignmentrequestCancelParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentrequestCancelParameter, AccesspackageassignmentrequestCancelResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-cancel?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestCancelResponse> AccesspackageassignmentrequestCancelAsync(AccesspackageassignmentrequestCancelParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentrequestCancelParameter, AccesspackageassignmentrequestCancelResponse>(parameter, cancellationToken);
        }
    }
}
