using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentrequestGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string AccessPackageAssignmentRequestId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId: return $"/identityGovernance/entitlementManagement/assignmentRequests/{AccessPackageAssignmentRequestId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests_AccessPackageAssignmentRequestId,
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
    public partial class AccesspackageAssignmentrequestGetResponse : RestApiResponse
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
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageAssignment? Assignment { get; set; }
        public AccessPackageSubject? Requestor { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestGetResponse> AccesspackageAssignmentrequestGetAsync()
        {
            var p = new AccesspackageAssignmentrequestGetParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestGetParameter, AccesspackageAssignmentrequestGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestGetResponse> AccesspackageAssignmentrequestGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentrequestGetParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestGetParameter, AccesspackageAssignmentrequestGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestGetResponse> AccesspackageAssignmentrequestGetAsync(AccesspackageAssignmentrequestGetParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestGetParameter, AccesspackageAssignmentrequestGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestGetResponse> AccesspackageAssignmentrequestGetAsync(AccesspackageAssignmentrequestGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestGetParameter, AccesspackageAssignmentrequestGetResponse>(parameter, cancellationToken);
        }
    }
}
