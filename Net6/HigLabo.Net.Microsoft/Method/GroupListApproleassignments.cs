using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class GroupListApproleAssignmentsParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string Id { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Groups_Id_AppRoleAssignments: return $"/groups/{Id}/appRoleAssignments";
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
            Groups_Id_AppRoleAssignments,
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
    public partial class GroupListApproleAssignmentsResponse : RestApiResponse
    {
        public AppRoleAssignment[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleAssignmentsResponse> GroupListApproleAssignmentsAsync()
        {
            var p = new GroupListApproleAssignmentsParameter();
            return await this.SendAsync<GroupListApproleAssignmentsParameter, GroupListApproleAssignmentsResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleAssignmentsResponse> GroupListApproleAssignmentsAsync(CancellationToken cancellationToken)
        {
            var p = new GroupListApproleAssignmentsParameter();
            return await this.SendAsync<GroupListApproleAssignmentsParameter, GroupListApproleAssignmentsResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleAssignmentsResponse> GroupListApproleAssignmentsAsync(GroupListApproleAssignmentsParameter parameter)
        {
            return await this.SendAsync<GroupListApproleAssignmentsParameter, GroupListApproleAssignmentsResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/group-list-approleassignments?view=graph-rest-1.0
        /// </summary>
        public async Task<GroupListApproleAssignmentsResponse> GroupListApproleAssignmentsAsync(GroupListApproleAssignmentsParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<GroupListApproleAssignmentsParameter, GroupListApproleAssignmentsResponse>(parameter, cancellationToken);
        }
    }
}
