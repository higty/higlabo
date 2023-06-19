using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public partial class ConditionalAccessRootPostPoliciesParameter : IRestApiParameter
    {
        public class ApiPathSettings
        {
            public ApiPath ApiPath { get; set; }

            public string GetApiPath()
            {
                switch (this.ApiPath)
                {
                    case ApiPath.Identity_ConditionalAccess_Policies: return $"/identity/conditionalAccess/policies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.ApiPath);
                }
            }
        }

        public enum ConditionalAccessPolicyConditionalAccessPolicyState
        {
            Enabled,
            Disabled,
            EnabledForReportingButNotEnforced,
        }
        public enum ApiPath
        {
            Identity_ConditionalAccess_Policies,
        }

        public ApiPathSettings ApiPathSetting { get; set; } = new ApiPathSettings();
        string IRestApiParameter.ApiPath
        {
            get
            {
                return this.ApiPathSetting.GetApiPath();
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
        public ConditionalAccessConditionSet? Conditions { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public ConditionalAccessGrantControls? GrantControls { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ConditionalAccessSessionControls? SessionControls { get; set; }
        public ConditionalAccessPolicyConditionalAccessPolicyState State { get; set; }
    }
    public partial class ConditionalAccessRootPostPoliciesResponse : RestApiResponse
    {
        public enum ConditionalAccessPolicyConditionalAccessPolicyState
        {
            Enabled,
            Disabled,
            EnabledForReportingButNotEnforced,
        }

        public ConditionalAccessConditionSet? Conditions { get; set; }
        public DateTimeOffset? CreatedDateTime { get; set; }
        public string? DisplayName { get; set; }
        public ConditionalAccessGrantControls? GrantControls { get; set; }
        public string? Id { get; set; }
        public DateTimeOffset? ModifiedDateTime { get; set; }
        public ConditionalAccessSessionControls? SessionControls { get; set; }
        public ConditionalAccessPolicyConditionalAccessPolicyState State { get; set; }
    }
    /// <summary>
    /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
    /// </summary>
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostPoliciesResponse> ConditionalAccessRootPostPoliciesAsync()
        {
            var p = new ConditionalAccessRootPostPoliciesParameter();
            return await this.SendAsync<ConditionalAccessRootPostPoliciesParameter, ConditionalAccessRootPostPoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostPoliciesResponse> ConditionalAccessRootPostPoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalAccessRootPostPoliciesParameter();
            return await this.SendAsync<ConditionalAccessRootPostPoliciesParameter, ConditionalAccessRootPostPoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostPoliciesResponse> ConditionalAccessRootPostPoliciesAsync(ConditionalAccessRootPostPoliciesParameter parameter)
        {
            return await this.SendAsync<ConditionalAccessRootPostPoliciesParameter, ConditionalAccessRootPostPoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://learn.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async ValueTask<ConditionalAccessRootPostPoliciesResponse> ConditionalAccessRootPostPoliciesAsync(ConditionalAccessRootPostPoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalAccessRootPostPoliciesParameter, ConditionalAccessRootPostPoliciesResponse>(parameter, cancellationToken);
        }
    }
}
