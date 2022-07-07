using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentrequestDeleteParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string AccessPackageAssignmentRequestId { get; set; }
    }
    public partial class AccesspackageassignmentrequestDeleteResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestDeleteResponse> AccesspackageassignmentrequestDeleteAsync()
        {
            var p = new AccesspackageassignmentrequestDeleteParameter();
            return await this.SendAsync<AccesspackageassignmentrequestDeleteParameter, AccesspackageassignmentrequestDeleteResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestDeleteResponse> AccesspackageassignmentrequestDeleteAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentrequestDeleteParameter();
            return await this.SendAsync<AccesspackageassignmentrequestDeleteParameter, AccesspackageassignmentrequestDeleteResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestDeleteResponse> AccesspackageassignmentrequestDeleteAsync(AccesspackageassignmentrequestDeleteParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentrequestDeleteParameter, AccesspackageassignmentrequestDeleteResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-delete?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestDeleteResponse> AccesspackageassignmentrequestDeleteAsync(AccesspackageassignmentrequestDeleteParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentrequestDeleteParameter, AccesspackageassignmentrequestDeleteResponse>(parameter, cancellationToken);
        }
    }
}
