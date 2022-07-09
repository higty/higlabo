using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleInstances/filterByCurrentUser";
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
            RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser,
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
    public partial class UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse : RestApiResponse
    {
        public UnifiedRoleEligibilityScheduleInstance[]? Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserAsync()
        {
            var p = new UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserAsync(UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserAsync(UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentUserResponse>(parameter, cancellationToken);
        }
    }
}
