using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class AccesspackageAssignmentGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? AccessPackageAssignmentId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments_AccessPackageAssignmentId: return $"/identityGovernance/entitlementManagement/assignments/{AccessPackageAssignmentId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments_AccessPackageAssignmentId,
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
    public partial class AccesspackageAssignmentGetResponse : RestApiResponse
    {
        public enum AccessPackageAssignmentAccessPackageAssignmentState
        {
            Delivering,
            PartiallyDelivered,
            Delivered,
            Expired,
            DeliveryFailed,
            UnknownFutureValue,
            Eq,
        }

        public DateTimeOffset? ExpiredDateTime { get; set; }
        public string? Id { get; set; }
        public EntitlementManagementSchedule? Schedule { get; set; }
        public AccessPackageAssignmentAccessPackageAssignmentState State { get; set; }
        public string? Status { get; set; }
        public AccessPackage? AccessPackage { get; set; }
        public AccessPackageSubject? Target { get; set; }
        public AccessPackageAssignmentPolicy? AssignmentPolicy { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentGetResponse> AccesspackageAssignmentGetAsync()
        {
            var p = new AccesspackageAssignmentGetParameter();
            return await this.SendAsync<AccesspackageAssignmentGetParameter, AccesspackageAssignmentGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentGetResponse> AccesspackageAssignmentGetAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentGetParameter();
            return await this.SendAsync<AccesspackageAssignmentGetParameter, AccesspackageAssignmentGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentGetResponse> AccesspackageAssignmentGetAsync(AccesspackageAssignmentGetParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentGetParameter, AccesspackageAssignmentGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignment-get?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentGetResponse> AccesspackageAssignmentGetAsync(AccesspackageAssignmentGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentGetParameter, AccesspackageAssignmentGetResponse>(parameter, cancellationToken);
        }
    }
}
