using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityscheduleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilitySchedules_UnifiedRoleEligibilityScheduleId,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules_UnifiedRoleEligibilityScheduleId: return $"/roleManagement/directory/roleEligibilitySchedules/{UnifiedRoleEligibilityScheduleId}";
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
        public string UnifiedRoleEligibilityScheduleId { get; set; }
    }
    public partial class UnifiedroleeligibilityscheduleGetResponse : RestApiResponse
    {
        public string? AppScopeId { get; set; }
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
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleGetResponse> UnifiedroleeligibilityscheduleGetAsync()
        {
            var p = new UnifiedroleeligibilityscheduleGetParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleGetParameter, UnifiedroleeligibilityscheduleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleGetResponse> UnifiedroleeligibilityscheduleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityscheduleGetParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleGetParameter, UnifiedroleeligibilityscheduleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleGetResponse> UnifiedroleeligibilityscheduleGetAsync(UnifiedroleeligibilityscheduleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleGetParameter, UnifiedroleeligibilityscheduleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleGetResponse> UnifiedroleeligibilityscheduleGetAsync(UnifiedroleeligibilityscheduleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleGetParameter, UnifiedroleeligibilityscheduleGetResponse>(parameter, cancellationToken);
        }
    }
}
