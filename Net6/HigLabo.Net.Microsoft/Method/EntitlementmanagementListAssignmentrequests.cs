using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class EntitlementManagementListAssignmentrequestsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests: return $"/identityGovernance/entitlementManagement/assignmentRequests";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            CompletedDateTime,
            CreatedDateTime,
            Id,
            RequestType,
            Schedule,
            State,
            Status,
            AccessPackage,
            Assignment,
            Requestor,
        }
        public enum ApiPath
        {
            IdentityGovernance_EntitlementManagement_AssignmentRequests,
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
    public partial class EntitlementManagementListAssignmentrequestsResponse : RestApiResponse
    {
        public AccessPackageAssignmentRequest[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentrequestsResponse> EntitlementManagementListAssignmentrequestsAsync()
        {
            var p = new EntitlementManagementListAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentrequestsParameter, EntitlementManagementListAssignmentrequestsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentrequestsResponse> EntitlementManagementListAssignmentrequestsAsync(CancellationToken cancellationToken)
        {
            var p = new EntitlementManagementListAssignmentrequestsParameter();
            return await this.SendAsync<EntitlementManagementListAssignmentrequestsParameter, EntitlementManagementListAssignmentrequestsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentrequestsResponse> EntitlementManagementListAssignmentrequestsAsync(EntitlementManagementListAssignmentrequestsParameter parameter)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentrequestsParameter, EntitlementManagementListAssignmentrequestsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/entitlementmanagement-list-assignmentrequests?view=graph-rest-1.0
        /// </summary>
        public async Task<EntitlementManagementListAssignmentrequestsResponse> EntitlementManagementListAssignmentrequestsAsync(EntitlementManagementListAssignmentrequestsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<EntitlementManagementListAssignmentrequestsParameter, EntitlementManagementListAssignmentrequestsResponse>(parameter, cancellationToken);
        }
    }
}
