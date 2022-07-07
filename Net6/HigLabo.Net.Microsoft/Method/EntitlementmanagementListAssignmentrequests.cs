using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListAssignmentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests: return $"/identityGovernance/entitlementManagement/assignmentRequests";
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
    public partial class EntitlementmanagementListAssignmentrequestsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentrequestsResponse> EntitlementmanagementListAssignmentrequestsAsync()
        {
            var p = new EntitlementmanagementListAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentrequestsParameter, EntitlementmanagementListAssignmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentrequestsResponse> EntitlementmanagementListAssignmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentrequestsParameter, EntitlementmanagementListAssignmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentrequestsResponse> EntitlementmanagementListAssignmentrequestsAsync(EntitlementmanagementListAssignmentrequestsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentrequestsParameter, EntitlementmanagementListAssignmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentrequestsResponse> EntitlementmanagementListAssignmentrequestsAsync(EntitlementmanagementListAssignmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentrequestsParameter, EntitlementmanagementListAssignmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
