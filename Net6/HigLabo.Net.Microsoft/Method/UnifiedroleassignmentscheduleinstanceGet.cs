using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentscheduleinstanceGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentScheduleInstances_UnifiedRoleAssignmentScheduleInstanceId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentScheduleInstances_UnifiedRoleAssignmentScheduleInstanceId: return $"/roleManagement/directory/roleAssignmentScheduleInstances/{UnifiedRoleAssignmentScheduleInstanceId}";
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
        public string UnifiedRoleAssignmentScheduleInstanceId { get; set; }
    }
    public partial class UnifiedroleassignmentscheduleinstanceGetResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceGetResponse> UnifiedroleassignmentscheduleinstanceGetAsync()
        {
            var p = new UnifiedroleassignmentscheduleinstanceGetParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceGetParameter, UnifiedroleassignmentscheduleinstanceGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceGetResponse> UnifiedroleassignmentscheduleinstanceGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentscheduleinstanceGetParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceGetParameter, UnifiedroleassignmentscheduleinstanceGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceGetResponse> UnifiedroleassignmentscheduleinstanceGetAsync(UnifiedroleassignmentscheduleinstanceGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceGetParameter, UnifiedroleassignmentscheduleinstanceGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentscheduleinstance-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleinstanceGetResponse> UnifiedroleassignmentscheduleinstanceGetAsync(UnifiedroleassignmentscheduleinstanceGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleinstanceGetParameter, UnifiedroleassignmentscheduleinstanceGetResponse>(parameter, cancellationToken);
        }
    }
}
