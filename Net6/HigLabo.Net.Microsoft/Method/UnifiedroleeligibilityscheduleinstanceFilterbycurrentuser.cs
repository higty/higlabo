using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
        public enum ApiPath
        {
            RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.RoleManagement_Directory_RoleEligibilityScheduleInstances_FilterByCurrentUser: return $"/roleManagement/directory/roleEligibilityScheduleInstances/filterByCurrentUser";
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
    }
    public partial class UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/unifiedroleeligibilityscheduleinstance?view=graph-rest-1.0
        /// </summary>
        public partial class UnifiedRoleEligibilityScheduleInstance
        {
            public string? AppScopeId { get; set; }
            public string? DirectoryScopeId { get; set; }
            public DateTimeOffset? EndDateTime { get; set; }
            public string? Id { get; set; }
            public string? MemberType { get; set; }
            public string? PrincipalId { get; set; }
            public string? RoleDefinitionId { get; set; }
            public string? RoleEligibilityScheduleId { get; set; }
            public DateTimeOffset? StartDateTime { get; set; }
        }

        public UnifiedRoleEligibilityScheduleInstance[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserAsync()
        {
            var p = new UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter();
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserAsync(UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter parameter)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/unifiedroleeligibilityscheduleinstance-filterbycurrentuser?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse> UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserAsync(UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserParameter, UnifiedroleeligibilityscheduleinstanceFilterbycurrentuserResponse>(parameter, cancellationToken);
        }
    }
}
