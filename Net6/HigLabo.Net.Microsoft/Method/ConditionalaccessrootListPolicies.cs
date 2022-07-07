using HigLabo.Net.OAuth;

namespace HigLabo.Net.Microsoft
{
    public partial class ConditionalaccessrootListPoliciesParameter : IRestApiParameter, IQueryParameterProperty
    {
        public enum Field
        {
        }
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
    public partial class ConditionalaccessrootListPoliciesResponse : RestApiResponse
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/resources/conditionalaccesspolicy?view=graph-rest-1.0
        /// </summary>
        public partial class ConditionalAccessPolicy
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

        public ConditionalAccessPolicy[] Value { get; set; }
    }
    public partial class MicrosoftClient
    {
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListPoliciesResponse> ConditionalaccessrootListPoliciesAsync()
        {
            var p = new ConditionalaccessrootListPoliciesParameter();
            return await this.SendAsync<ConditionalaccessrootListPoliciesParameter, ConditionalaccessrootListPoliciesResponse>(p, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListPoliciesResponse> ConditionalaccessrootListPoliciesAsync(CancellationToken cancellationToken)
        {
            var p = new ConditionalaccessrootListPoliciesParameter();
            return await this.SendAsync<ConditionalaccessrootListPoliciesParameter, ConditionalaccessrootListPoliciesResponse>(p, cancellationToken);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListPoliciesResponse> ConditionalaccessrootListPoliciesAsync(ConditionalaccessrootListPoliciesParameter parameter)
        {
            return await this.SendAsync<ConditionalaccessrootListPoliciesParameter, ConditionalaccessrootListPoliciesResponse>(parameter, CancellationToken.None);
        }
        /// <summary>
        /// https://docs.microsoft.com/en-us/graph/api/conditionalaccessroot-list-policies?view=graph-rest-1.0
        /// </summary>
        public async Task<ConditionalaccessrootListPoliciesResponse> ConditionalaccessrootListPoliciesAsync(ConditionalaccessrootListPoliciesParameter parameter, CancellationToken cancellationToken)
        {
            return await this.SendAsync<ConditionalaccessrootListPoliciesParameter, ConditionalaccessrootListPoliciesResponse>(parameter, cancellationToken);
        }
    }
}
