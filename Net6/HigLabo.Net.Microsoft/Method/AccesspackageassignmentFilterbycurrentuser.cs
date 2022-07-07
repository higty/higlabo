using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageassignmentFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignments/filterByCurrentUser";
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
    public partial class AccesspackageassignmentFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/accesspackageassignment?view=graph-rest-1.0
        /// </summary>
        public partial class AccessPackageAssignment
        {
            public enum AccessPackageAssignmentAccessPackageAssignmentState
            {
                Delivering,
                PartiallyDelivered,
                Delivered,
                Expired,
                DeliveryFailed,
                UnknownFutureValue,
            }

            public DateTimeOffset? ExpiredDateTime { get; set; }
            public string? Id { get; set; }
            public EntitlementManagementSchedule? Schedule { get; set; }
            public AccessPackageAssignmentAccessPackageAssignmentState State { get; set; }
            public string? Status { get; set; }
        }

        public AccessPackageAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentFilterbycurrentuserResponse> AccesspackageassignmentFilterbycurrentuserAsync()
        {
            var p = new AccesspackageassignmentFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageassignmentFilterbycurrentuserParameter, AccesspackageassignmentFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentFilterbycurrentuserResponse> AccesspackageassignmentFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageassignmentFilterbycurrentuserParameter();
            return await this.SendAsync<AccesspackageassignmentFilterbycurrentuserParameter, AccesspackageassignmentFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentFilterbycurrentuserResponse> AccesspackageassignmentFilterbycurrentuserAsync(AccesspackageassignmentFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<AccesspackageassignmentFilterbycurrentuserParameter, AccesspackageassignmentFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageassignmentFilterbycurrentuserResponse> AccesspackageassignmentFilterbycurrentuserAsync(AccesspackageassignmentFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageassignmentFilterbycurrentuserParameter, AccesspackageassignmentFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
