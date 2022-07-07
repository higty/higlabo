using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
        string IRestApiParameter.HttpMethod { get; } = "GET";
        public QueryParameter<Field> Query { get; set; } = new QueryParameter<Field>();
        IQueryParameter IQueryParameterProperty.Query
        {
            get
            {
                return this.Query;
            }
        }
        public string AccessPackageAssignmentRequestId { get; set; }
    }
    public partial class AccesspackageassignmentrequestGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestGetResponse> AccesspackageassignmentrequestGetAsync()
        {
            var p = new AccesspackageassignmentrequestGetParameter();
            return await this.SendAsync<AccesspackageassignmentrequestGetParameter, AccesspackageassignmentrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestGetResponse> AccesspackageassignmentrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentrequestGetParameter();
            return await this.SendAsync<AccesspackageassignmentrequestGetParameter, AccesspackageassignmentrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestGetResponse> AccesspackageassignmentrequestGetAsync(AccesspackageassignmentrequestGetParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentrequestGetParameter, AccesspackageassignmentrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentrequestGetResponse> AccesspackageassignmentrequestGetAsync(AccesspackageassignmentrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentrequestGetParameter, AccesspackageassignmentrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
