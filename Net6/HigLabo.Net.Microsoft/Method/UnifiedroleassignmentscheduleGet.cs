using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleAssignmentscheduleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string UnifiedRoleAssignmentScheduleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules_UnifiedRoleAssignmentScheduleId: return $"/roleManagement/directory/roleAssignmentSchedules/{UnifiedRoleAssignmentScheduleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules_UnifiedRoleAssignmentScheduleId,
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
    public partial class UnifiedroleAssignmentscheduleGetResponse : RestApiResponse
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
        public UnifiedRoleEligibilitySchedule? ActivatedUsing { get; set; }
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentscheduleGetResponse> UnifiedroleAssignmentscheduleGetAsync()
        {
            var p = new UnifiedroleAssignmentscheduleGetParameter();
            return await this.SendAsync<UnifiedroleAssignmentscheduleGetParameter, UnifiedroleAssignmentscheduleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentscheduleGetResponse> UnifiedroleAssignmentscheduleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentscheduleGetParameter();
            return await this.SendAsync<UnifiedroleAssignmentscheduleGetParameter, UnifiedroleAssignmentscheduleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentscheduleGetResponse> UnifiedroleAssignmentscheduleGetAsync(UnifiedroleAssignmentscheduleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentscheduleGetParameter, UnifiedroleAssignmentscheduleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleAssignmentscheduleGetResponse> UnifiedroleAssignmentscheduleGetAsync(UnifiedroleAssignmentscheduleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentscheduleGetParameter, UnifiedroleAssignmentscheduleGetResponse>(parameter, cancellationToken);
        }
    }
}
