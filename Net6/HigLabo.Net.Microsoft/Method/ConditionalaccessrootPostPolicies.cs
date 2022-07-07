using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccessrootPostPoliciesParameter : IRestApiParameter
    {
        public enum ApiPath
        {
            Identity_ConditionalAccess_Policies,
        }

        public ApiPath Path { get; set; }
        string IRestApiParameter.ApiPath
        {
            get
            {
                switch (this.Path)
                {
                    case ApiPath.Identity_ConditionalAccess_Policies: return $"/identity/conditionalAccess/policies";
                    default:throw new HigLabo.Core.SwitchStatementNotImplementException<ApiPath>(this.Path);
                }
            }
        }
        string IRestApiParameter.HttpMethod { get; } = "POST";
    }
    public partial class ConditionalaccessrootPostPoliciesResponse : RestApiResponse
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
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostPoliciesResponse> ConditionalaccessrootPostPoliciesAsync()
        {
            var p = new ConditionalaccessrootPostPoliciesParameter();
            return await this.SendAsync<ConditionalaccessrootPostPoliciesParameter, ConditionalaccessrootPostPoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostPoliciesResponse> ConditionalaccessrootPostPoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccessrootPostPoliciesParameter();
            return await this.SendAsync<ConditionalaccessrootPostPoliciesParameter, ConditionalaccessrootPostPoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostPoliciesResponse> ConditionalaccessrootPostPoliciesAsync(ConditionalaccessrootPostPoliciesParameter parameter)
        {
            return await this.SendAsync<ConditionalaccessrootPostPoliciesParameter, ConditionalaccessrootPostPoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-post-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootPostPoliciesResponse> ConditionalaccessrootPostPoliciesAsync(ConditionalaccessrootPostPoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccessrootPostPoliciesParameter, ConditionalaccessrootPostPoliciesResponse>(parameter, cancellationToken);
        }
    }
}
