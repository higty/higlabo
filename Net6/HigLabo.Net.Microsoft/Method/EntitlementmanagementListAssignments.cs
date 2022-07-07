using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementmanagementListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments: return $"/identityGovernance/entitlementManagement/assignments";
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
    public partial class EntitlementmanagementListAssignmentsResponse : RestApiResponse
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
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentsResponse> EntitlementmanagementListAssignmentsAsync()
        {
            var p = new EntitlementmanagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentsParameter, EntitlementmanagementListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentsResponse> EntitlementmanagementListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementmanagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementmanagementListAssignmentsParameter, EntitlementmanagementListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentsResponse> EntitlementmanagementListAssignmentsAsync(EntitlementmanagementListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentsParameter, EntitlementmanagementListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementmanagementListAssignmentsResponse> EntitlementmanagementListAssignmentsAsync(EntitlementmanagementListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementmanagementListAssignmentsParameter, EntitlementmanagementListAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
