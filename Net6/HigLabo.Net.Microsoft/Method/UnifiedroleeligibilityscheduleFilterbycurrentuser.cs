using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleeligibilityscheduleFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilitySchedules_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilitySchedules/filterByCurrentUser";
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
            RoleManagement_Directory_RoleEligibilitySchedules_FilterByCurrentUser,
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
    public partial class UnifiedroleeligibilityscheduleFilterbycurrentUserResponse : RestApiResponse
    {
        public UnifiedRoleEligibilitySchedule[]? Value { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleeligibilityscheduleFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityscheduleFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleFilterbycurrentUserAsync(UnifiedroleeligibilityscheduleFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedroleeligibilityschedule-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleFilterbycurrentUserAsync(UnifiedroleeligibilityscheduleFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
