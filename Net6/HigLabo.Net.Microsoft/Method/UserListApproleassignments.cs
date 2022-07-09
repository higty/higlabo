using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserListApproleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? IdOrUserPrincipalName { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Users_IdOrUserPrincipalName_AppRoleAssignments: return $"/users/{IdOrUserPrincipalName}/appRoleAssignments";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppRoleId,
            CreatedDateTime,
            Id,
            PrincipalDisplayName,
            PrincipalId,
            PrincipalType,
            ResourceDisplayName,
            ResourceId,
        }
        public enum ApiPath
        {
            Users_IdOrUserPrincipalName_AppRoleAssignments,
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
    public partial class UserListApproleAssignmentsResponse : RestApiResponse
    {
        public AppRoleAssignment[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync()
        {
            var p = new UserListApproleAssignmentsParameter();
            return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new UserListApproleAssignmentsParameter();
            return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(UserListApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserListApproleAssignmentsResponse> UserListApproleAssignmentsAsync(UserListApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserListApproleAssignmentsParameter, UserListApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
