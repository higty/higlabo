using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
    /// </summary>
    public partial class UnifiedroleManagementPolicyruleUpdateParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }
            public string? UnifiedRoleManagementPolicyId { get; set; }
            public string? UnifiedRoleManagementPolicyRuleId { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId: return $"/policies/roleManagementPolicies/{UnifiedRoleManagementPolicyId}/rules/{UnifiedRoleManagementPolicyRuleId}";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ApiPath
        {
            Policies_RoleManagementPolicies_UnifiedRoleManagementPolicyId_Rules_UnifiedRoleManagementPolicyRuleId,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "PATCH";
        public string? ClaimValue { get; set; }
        public String[]? EnabledRules { get; set; }
        public bool? IsDefaultRecipientsEnabled { get; set; }
        public bool? IsEnabled { get; set; }
        public bool? IsExpirationRequired { get; set; }
        public string? MaximumDuration { get; set; }
        public string? NotificationLevel { get; set; }
        public String[]? NotificationRecipients { get; set; }
        public string? NotificationType { get; set; }
        public string? RecipientType { get; set; }
        public ApprovalSettings? Setting { get; set; }
        public UnifiedRoleManagementPolicyRuleTarget? Target { get; set; }
    }
    public partial class UnifiedroleManagementPolicyruleUpdateResponse : RestApiResponse
    {
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleUpdateResponse> UnifiedroleManagementPolicyruleUpdateAsync()
        {
            var p = new UnifiedroleManagementPolicyruleUpdateParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyruleUpdateParameter, UnifiedroleManagementPolicyruleUpdateResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleUpdateResponse> UnifiedroleManagementPolicyruleUpdateAsync(CancellationToken cancellationToken)
        {
            var p = new UnifiedroleManagementPolicyruleUpdateParameter();
            return await this.SendAsync<UnifiedroleManagementPolicyruleUpdateParameter, UnifiedroleManagementPolicyruleUpdateResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleUpdateResponse> UnifiedroleManagementPolicyruleUpdateAsync(UnifiedroleManagementPolicyruleUpdateParameter parameter)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyruleUpdateParameter, UnifiedroleManagementPolicyruleUpdateResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/unifiedrolemanagementpolicyrule-update?view=graph-rest-1.0
        /// </summary>
        public async Task<UnifiedroleManagementPolicyruleUpdateResponse> UnifiedroleManagementPolicyruleUpdateAsync(UnifiedroleManagementPolicyruleUpdateParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<UnifiedroleManagementPolicyruleUpdateParameter, UnifiedroleManagementPolicyruleUpdateResponse>(parameter, cancellationToken);
        }
    }
}
