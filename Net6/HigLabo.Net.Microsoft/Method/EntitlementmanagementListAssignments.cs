using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class EntitlementManagementListAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments: return $"/identityGovernance/entitlementManagement/assignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            ExpiredDateTime,
            Id,
            Schedule,
            State,
            Status,
            AccessPackage,
            Target,
            AssignmentPolicy,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_Assignments,
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
    public partial class EntitlementManagementListAssignmentsResponse : RestApiResponse
    {
        public AccessPackageAssignment[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync()
        {
            var p = new EntitlementManagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(EntitlementManagementListAssignmentsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignments?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentsResponse> EntitlementManagementListAssignmentsAsync(EntitlementManagementListAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentsParameter, EntitlementManagementListAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
