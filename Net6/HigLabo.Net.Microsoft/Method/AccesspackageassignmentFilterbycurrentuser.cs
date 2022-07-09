using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class AccesspackageAssignmentFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser: return $"/identityGovernance/entitlementManagement/assignments/filterByCurrentUser";
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
            IdentityGovernance_EntitlementManagement_Assignments_FilterByCurrentUser,
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
    public partial class AccesspackageAssignmentFilterbycurrentUserResponse : RestApiResponse
    {
        public AccessPackageAssignment[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentFilterbycurrentUserResponse> AccesspackageAssignmentFilterbycurrentUserAsync()
        {
            var p = new AccesspackageAssignmentFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentFilterbycurrentUserParameter, AccesspackageAssignmentFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentFilterbycurrentUserResponse> AccesspackageAssignmentFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new AccesspackageAssignmentFilterbycurrentUserParameter();
            return await this.SendAsync<AccesspackageAssignmentFilterbycurrentUserParameter, AccesspackageAssignmentFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentFilterbycurrentUserResponse> AccesspackageAssignmentFilterbycurrentUserAsync(AccesspackageAssignmentFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<AccesspackageAssignmentFilterbycurrentUserParameter, AccesspackageAssignmentFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/accesspackageassignment-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<AccesspackageAssignmentFilterbycurrentUserResponse> AccesspackageAssignmentFilterbycurrentUserAsync(AccesspackageAssignmentFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<AccesspackageAssignmentFilterbycurrentUserParameter, AccesspackageAssignmentFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
