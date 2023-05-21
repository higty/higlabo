using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleeligibilityschedulesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules: return $"/roleManagement/directory/roleEligibilitySchedules";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppScopeId,
            CreatedDateTime,
            CreatedUsing,
            DirectoryScopeId,
            Id,
            MemberType,
            ModifiedDateTime,
            PrincipalId,
            RoleDefinitionId,
            ScheduleInfo,
            Status,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilitySchedules,
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
    public partial class RbacapplicationListRoleeligibilityschedulesResponse : RestApiResponse
    {
        public UnifiedRoleEligibilitySchedule[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync()
        {
            var p = new RbacapplicationListRoleeligibilityschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleeligibilityschedulesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(RbacapplicationListRoleeligibilityschedulesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityschedules?view=graph-rest-1.0
        /// </summary>
        public async Task<RbacapplicationListRoleeligibilityschedulesResponse> RbacapplicationListRoleeligibilityschedulesAsync(RbacapplicationListRoleeligibilityschedulesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityschedulesParameter, RbacapplicationListRoleeligibilityschedulesResponse>(parameter, cancellationToken);
        }
    }
}
