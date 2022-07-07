using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentrequestFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignmentRequests/filterByCurrentUser";
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
    public partial class AccesspackageassignmentrequestFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignmentrequest?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackageAssignmentRequest
        {
            public enum AccessPackageAssignmentRequestAccessPackageRequestType
            {
                NotSpecified,
                UserAdd,
                UserUpdate,
                UserRemove,
                AdminAdd,
                AdminUpdate,
                AdminRemove,
                SystemAdd,
                SystemUpdate,
                SystemRemove,
                OnBehalfAdd,
                UnknownFutureValue,
            }
            public enum AccessPackageAssignmentRequestAccessPackageRequestState
            {
                Submitted,
                PendingApproval,
                Delivering,
                Delivered,
                DeliveryFailed,
                Denied,
                Scheduled,
                Canceled,
                PartiallyDelivered,
                UnknownFutureValue,
            }

            public DateTimeOffset? CompletedDateTime { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public AccessPackageAssignmentRequestAccessPackageRequestType RequestType { get; set; }
            public EntitlementManagementSchedule? Schedule { get; set; }
            public AccessPackageAssignmentRequestAccessPackageRequestState State { get; set; }
            public string? Status { get; set; }
        }

        public AccessPackageAssignmentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestFilterbycurrentuserResponse> AccesspackageassignmentrequestFilterbycurrentuserAsync()
        {
            var p = new AccesspackageassignmentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageassignmentrequestFilterbycurrentuserParameter, AccesspackageassignmentrequestFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestFilterbycurrentuserResponse> AccesspackageassignmentrequestFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentrequestFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageassignmentrequestFilterbycurrentuserParameter, AccesspackageassignmentrequestFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestFilterbycurrentuserResponse> AccesspackageassignmentrequestFilterbycurrentuserAsync(AccesspackageassignmentrequestFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentrequestFilterbycurrentuserParameter, AccesspackageassignmentrequestFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestFilterbycurrentuserResponse> AccesspackageassignmentrequestFilterbycurrentuserAsync(AccesspackageassignmentrequestFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentrequestFilterbycurrentuserParameter, AccesspackageassignmentrequestFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
