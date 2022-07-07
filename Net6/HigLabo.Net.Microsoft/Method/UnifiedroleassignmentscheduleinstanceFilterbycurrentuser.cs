using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleInstances_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentScheduleInstances/filterByCurrentUser";
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
    }
    public partial class UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleassignmentscheduleinstance?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleAssignmentScheduleInstance
        {
            public string? AppScopeId { get; set; }
            public string? AssignmentType { get; set; }
            public string? DirectoryScopeId { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public string? Id { get; set; }
            public string? MemberType { get; set; }
            public string? PrincipalId { get; set; }
            public string? RoleAssignmentOriginId { get; set; }
            public string? RoleAssignmentScheduleId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
        }

        public UnifiedRoleAssignmentScheduleInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse> UnifiedroleassignmentscheduleinstanceFilterbycurrentuserAsync()
        {
            var p = new UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter, UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse> UnifiedroleassignmentscheduleinstanceFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter, UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse> UnifiedroleassignmentscheduleinstanceFilterbycurrentuserAsync(UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter, UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse> UnifiedroleassignmentscheduleinstanceFilterbycurrentuserAsync(UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceFilterbycurrentuserParameter, UnifiedroleassignmentscheduleinstanceFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
