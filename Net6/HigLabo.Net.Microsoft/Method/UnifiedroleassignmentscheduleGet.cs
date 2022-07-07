using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleassignmentscheduleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules_UnifiedRoleAssignmentScheduleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules_UnifiedRoleAssignmentScheduleId: return $"/roleManagement/directory/roleAssignmentSchedules/{UnifiedRoleAssignmentScheduleId}";
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
        public string UnifiedRoleAssignmentScheduleId { get; set; }
    }
    public partial class UnifiedroleassignmentscheduleGetResponse : RestApiResponse
    {
        public string? AppScopeId { get; set; }
        public string? AssignmentType { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? CreatedUsing { get; set; }
        public string? DirectoryScopeId { get; set; }
        public string? Id { get; set; }
        public string? MemberType { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public string? PrincipalId { get; set; }
        public string? RoleDefinitionId { get; set; }
        public RequestSchedule? ScheduleInfo { get; set; }
        public string? Status { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleGetResponse> UnifiedroleassignmentscheduleGetAsync()
        {
            var p = new UnifiedroleassignmentscheduleGetParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleGetParameter, UnifiedroleassignmentscheduleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleGetResponse> UnifiedroleassignmentscheduleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleassignmentscheduleGetParameter();
            return await this.SendAsync<UnifiedroleassignmentscheduleGetParameter, UnifiedroleassignmentscheduleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleGetResponse> UnifiedroleassignmentscheduleGetAsync(UnifiedroleassignmentscheduleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleGetParameter, UnifiedroleassignmentscheduleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleassignmentscheduleGetResponse> UnifiedroleassignmentscheduleGetAsync(UnifiedroleassignmentscheduleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleassignmentscheduleGetParameter, UnifiedroleassignmentscheduleGetResponse>(parameter, cancellationToken);
        }
    }
}
