using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentrequestFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignmentRequests/filterByCurrentUser";
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
            IdentityGovernance_EntitlementManagement_AssignmentRequests_FilterByCurrentUser,
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
    public partial class AccesspackageAssignmentrequestFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessPackageAssignmentRequest[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync()
        {
            var p = new AccesspackageAssignmentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(AccesspackageAssignmentrequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(AccesspackageAssignmentrequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
