using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListApproleassignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            Groups_Id_AppRoleAssignments,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Groups_Id_AppRoleAssignments: return $"/groups/{Id}/appRoleAssignments";
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
        public string Id { get; set; }
    }
    public partial class GroupListApproleassignmentsResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/approleassignment?view=graph-rest-1.0
        /// </summary>
        public partial class AppRoleAssignment
        {
            public Guid? AppRoleId { get; set; }
            public DateTimeOffset? CreatedDateTime { get; set; }
            public string? Id { get; set; }
            public string? PrincipalDisplayName { get; set; }
            public Guid? PrincipalId { get; set; }
            public string? PrincipalType { get; set; }
            public string? ResourceDisplayName { get; set; }
            public Guid? ResourceId { get; set; }
        }

        public AppRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleassignmentsResponse> GroupListApproleassignmentsAsync()
        {
            var p = new GroupListApproleassignmentsParameter();
            return await this.SendAsync<GroupListApproleassignmentsParameter, GroupListApproleassignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleassignmentsResponse> GroupListApproleassignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListApproleassignmentsParameter();
            return await this.SendAsync<GroupListApproleassignmentsParameter, GroupListApproleassignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleassignmentsResponse> GroupListApproleassignmentsAsync(GroupListApproleassignmentsParameter parameter)
        {
            return await this.SendAsync<GroupListApproleassignmentsParameter, GroupListApproleassignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleassignmentsResponse> GroupListApproleassignmentsAsync(GroupListApproleassignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListApproleassignmentsParameter, GroupListApproleassignmentsResponse>(parameter, cancellationToken);
        }
    }
}
