using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UserDeleteApproleassignmentsParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Users_Id_AppRoleAssignments_Id,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Users_Id_AppRoleAssignments_Id: return $"/users/{UsersId}/appRoleAssignments/{AppRoleAssignmentsId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "DELETE";
        public string UsersId { get; set; }
        public string AppRoleAssignmentsId { get; set; }
    }
    public partial class UserDeleteApproleassignmentsResponse : RestApiResponse
    {
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteApproleassignmentsResponse> UserDeleteApproleassignmentsAsync()
        {
            var p = new UserDeleteApproleassignmentsParameter();
            return await this.SendAsync<UserDeleteApproleassignmentsParameter, UserDeleteApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteApproleassignmentsResponse> UserDeleteApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new UserDeleteApproleassignmentsParameter();
            return await this.SendAsync<UserDeleteApproleassignmentsParameter, UserDeleteApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteApproleassignmentsResponse> UserDeleteApproleassignmentsAsync(UserDeleteApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<UserDeleteApproleassignmentsParameter, UserDeleteApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/user-delete-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<UserDeleteApproleassignmentsResponse> UserDeleteApproleassignmentsAsync(UserDeleteApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UserDeleteApproleassignmentsParameter, UserDeleteApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
