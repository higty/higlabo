using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class RbacapplicationListRoleeligibilityscheduleinstancesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleInstances: return $"/roleManagement/directory/roleEligibilityScheduleInstances";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppScopeId,
            DirectoryScopeId,
            EndDateTime,
            Id,
            MemberType,
            PrincipalId,
            RoleDefinitionId,
            RoleEligibilityScheduleId,
            StartDateTime,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleInstances,
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
    public partial class RbacapplicationListRoleeligibilityscheduleinstancesResponse : RestApiResponse
    {
        public UnifiedRoleEligibilityScheduleInstance[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleeligibilityscheduleinstancesResponse> RbacapplicationListRoleeligibilityscheduleinstancesAsync()
        {
            var p = new RbacapplicationListRoleeligibilityscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityscheduleinstancesParameter, RbacapplicationListRoleeligibilityscheduleinstancesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleeligibilityscheduleinstancesResponse> RbacapplicationListRoleeligibilityscheduleinstancesAsync(CancellationToken cancellationToken)
        {
            var p = new RbacapplicationListRoleeligibilityscheduleinstancesParameter();
            return await this.SendAsync<RbacapplicationListRoleeligibilityscheduleinstancesParameter, RbacapplicationListRoleeligibilityscheduleinstancesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleeligibilityscheduleinstancesResponse> RbacapplicationListRoleeligibilityscheduleinstancesAsync(RbacapplicationListRoleeligibilityscheduleinstancesParameter parameter)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityscheduleinstancesParameter, RbacapplicationListRoleeligibilityscheduleinstancesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/rbacapplication-list-roleeligibilityscheduleinstances?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<RbacapplicationListRoleeligibilityscheduleinstancesResponse> RbacapplicationListRoleeligibilityscheduleinstancesAsync(RbacapplicationListRoleeligibilityscheduleinstancesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<RbacapplicationListRoleeligibilityscheduleinstancesParameter, RbacapplicationListRoleeligibilityscheduleinstancesResponse>(parameter, cancellationToken);
        }
    }
}
