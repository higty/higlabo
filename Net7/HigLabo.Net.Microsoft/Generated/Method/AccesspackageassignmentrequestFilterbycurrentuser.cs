using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
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
            Answers,
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
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync()
        {
            var p = new AccesspackageAssignmentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentrequestFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(AccesspackageAssignmentrequestFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/accesspackageassignmentrequest-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<AccesspackageAssignmentrequestFilterbycurrentUserResponse> AccesspackageAssignmentrequestFilterbycurrentUserAsync(AccesspackageAssignmentrequestFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentrequestFilterbycurrentUserParameter, AccesspackageAssignmentrequestFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
