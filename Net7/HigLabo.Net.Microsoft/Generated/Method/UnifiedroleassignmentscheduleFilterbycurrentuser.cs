using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleAssignmentscheduleFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser: return $"/roleManagement/directory/roleAssignmentSchedules/filterByCurrentUser";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            AppScopeId,
            AssignmentType,
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
            ActivatedUsing,
            AppScope,
            DirectoryScope,
            Principal,
            RoleDefinition,
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleAssignmentSchedules_FilterByCurrentUser,
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
    public partial class UnifiedroleAssignmentscheduleFilterbycurrentUserResponse : RestApiResponse
    {
        public UnifiedRoleAssignmentSchedule[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentscheduleFilterbycurrentUserResponse> UnifiedroleAssignmentscheduleFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleAssignmentscheduleFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleAssignmentscheduleFilterbycurrentUserParameter, UnifiedroleAssignmentscheduleFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentscheduleFilterbycurrentUserResponse> UnifiedroleAssignmentscheduleFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleAssignmentscheduleFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleAssignmentscheduleFilterbycurrentUserParameter, UnifiedroleAssignmentscheduleFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentscheduleFilterbycurrentUserResponse> UnifiedroleAssignmentscheduleFilterbycurrentUserAsync(UnifiedroleAssignmentscheduleFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleAssignmentscheduleFilterbycurrentUserParameter, UnifiedroleAssignmentscheduleFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleassignmentschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<UnifiedroleAssignmentscheduleFilterbycurrentUserResponse> UnifiedroleAssignmentscheduleFilterbycurrentUserAsync(UnifiedroleAssignmentscheduleFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleAssignmentscheduleFilterbycurrentUserParameter, UnifiedroleAssignmentscheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
