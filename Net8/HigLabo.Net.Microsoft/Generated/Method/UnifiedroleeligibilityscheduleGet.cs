using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleeligibilityScheduleGetParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleEligibilityScheduleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules_UnifiedRoleEligibilityScheduleId: return $"/roleManagement/directory/roleEligibilitySchedules/{UnifiedRoleEligibilityScheduleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilitySchedules_UnifiedRoleEligibilityScheduleId,
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
    public partial class UnifiedroleeligibilityScheduleGetResponse : RestApiResponse
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
        public AppScope? AppScope { get; set; }
        public DirectoryObject? DirectoryScope { get; set; }
        public DirectoryObject? Principal { get; set; }
        public UnifiedRoleDefinition? RoleDefinition { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleGetResponse> UnifiedroleeligibilityScheduleGetAsync()
        {
            var p = new UnifiedroleeligibilityScheduleGetParameter();
            return await this.SendAsync<UnifiedroleeligibilityScheduleGetParameter, UnifiedroleeligibilityScheduleGetResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleGetResponse> UnifiedroleeligibilityScheduleGetAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityScheduleGetParameter();
            return await this.SendAsync<UnifiedroleeligibilityScheduleGetParameter, UnifiedroleeligibilityScheduleGetResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleGetResponse> UnifiedroleeligibilityScheduleGetAsync(UnifiedroleeligibilityScheduleGetParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityScheduleGetParameter, UnifiedroleeligibilityScheduleGetResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-get?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleeligibilityScheduleGetResponse> UnifiedroleeligibilityScheduleGetAsync(UnifiedroleeligibilityScheduleGetParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityScheduleGetParameter, UnifiedroleeligibilityScheduleGetResponse>(parameter, cancellationToken);
        }
    }
}
