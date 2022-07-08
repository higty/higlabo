using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class PolicyRootListRoleManagementpoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicies: return $"/policies/roleManagementPolicies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum Field
        {
            Description,
            DisplayName,
            Id,
            IsOrganizationDefault,
            LastModifiedBy,
            LastModifiedDateTime,
            ScopeId,
            ScopeType,
            EffectiveRules,
            Rules,
        }
        public enum ApiPath
        {
            Policies_RoleManagementPolicies,
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
    public partial class PolicyRootListRoleManagementpoliciesResponse : RestApiResponse
    {
        public UnifiedRoleManagementPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync()
        {
            var p = new PolicyRootListRoleManagementpoliciesParameter();
            return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new PolicyRootListRoleManagementpoliciesParameter();
            return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(PolicyRootListRoleManagementpoliciesParameter parameter)
        {
            return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/policyroot-list-rolemanagementpolicies?view=graph-rest-1.0
        /// </summary>
        public async Task<PolicyRootListRoleManagementpoliciesResponse> PolicyRootListRoleManagementpoliciesAsync(PolicyRootListRoleManagementpoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<PolicyRootListRoleManagementpoliciesParameter, PolicyRootListRoleManagementpoliciesResponse>(parameter, cancellationToken);
        }
    }
}
